using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace SABI
{
    public static class RigidbodyExtensions
    {
        public static Rigidbody ChangeDirection(this Rigidbody rigidbody, Vector3 direction)
        {
            direction.Normalize();
#if UNITY_6000_0_OR_NEWER
            rigidbody.linearVelocity = direction * rigidbody.linearVelocity.magnitude;
#else
            rigidbody.velocity = direction * rigidbody.velocity.magnitude;
#endif
            return rigidbody;
        }

        public static Rigidbody AddForceToReachVelocity(
            this Rigidbody rigidbody,
            Vector3 targetVelocity,
            float maxForce
        )
        {
            Vector3 velocityDiff = targetVelocity - rigidbody.velocity;
            Vector3 force = velocityDiff * rigidbody.mass / Time.fixedDeltaTime; // F = m*a
            force = Vector3.ClampMagnitude(force, maxForce);
            rigidbody.AddForce(force, ForceMode.Force);
            return rigidbody;
        }

        public static Rigidbody Stop(this Rigidbody rigidbody)
        {
            rigidbody.velocity = Vector3.zero;
            rigidbody.angularVelocity = Vector3.zero;
            return rigidbody;
        }

        public static bool IsAlmostStopped(this Rigidbody rigidbody, float threshold = 0.1f) =>
            rigidbody.velocity.magnitude < threshold;

        #region Simple Movements

        public static Rigidbody MoveTowards(this Rigidbody source, Transform target, float speed)
        {
            source.position = Vector3.MoveTowards(source.position, target.position, speed);
            return source;
        }

        public static Rigidbody MoveTowards(this Rigidbody source, Vector3 target, float speed)
        {
            source.position = Vector3.MoveTowards(source.position, target, speed);
            return source;
        }

        public static Rigidbody ContinuesChaseTargetWhile(
            this Rigidbody agent,
            Transform target,
            MonoBehaviour monoBehaviour,
            float speed = 5,
            float? minDistanceKeep = null,
            float? maxDistanceKeep = null,
            float? delayBetweenSettingDestination = null,
            Func<bool> loopCondition = null,
            Func<float> distanceToPlayer = null
        )
        {
            monoBehaviour.StartCoroutine(ChaseTargetCoroutine());

            IEnumerator ChaseTargetCoroutine()
            {
                WaitForSeconds delay = new WaitForSeconds(delayBetweenSettingDestination ?? 0);
                Vector3 selfPosition = agent.transform.position;

                while (
                    agent != null && target != null && loopCondition != null
                        ? loopCondition()
                        : true
                )
                {
                    float distance =
                        distanceToPlayer == null
                            ? agent.transform.Distance(target)
                            : distanceToPlayer();

                    if (minDistanceKeep == null || maxDistanceKeep == null)
                    {
                        agent.MoveTowards(target.position, speed * Time.deltaTime);
                    }
                    else
                    {
                        if (distance < minDistanceKeep.Value)
                        {
                            Vector3 directionToMoveWhenTooCloseToPlayer = (
                                target.position - selfPosition
                            ).normalized;
                            Vector3 positionToMove =
                                selfPosition
                                + (
                                    directionToMoveWhenTooCloseToPlayer
                                    * -1
                                    * (maxDistanceKeep.Value - distance)
                                );
                            agent.MoveTowards(
                                positionToMove.WithY(selfPosition.y),
                                speed * Time.deltaTime
                            );
                        }
                        else
                        {
                            agent.MoveTowards(target.position, speed * Time.deltaTime);
                        }
                    }

                    if (delayBetweenSettingDestination == null)
                        yield return null;
                    else
                        yield return delay;
                }
            }

            return agent;
        }

        public static bool SetRandomDestination(
            this Rigidbody agent,
            out Vector3 randomLocation,
            float radius,
            float speed,
            Vector3? origin = null
        )
        {
            Vector3 randomDirection = Random.insideUnitSphere * radius;
            randomLocation = randomDirection += origin ?? agent.transform.position;
            agent.MoveTowards(randomLocation, speed);
            return true;
        }

        public static bool SetRandomDestination(
            this Rigidbody agent,
            float radius,
            float speed,
            Vector3? origin = null
        )
        {
            Vector3 randomDirection = Random.insideUnitSphere * radius;
            Vector3 randomLocation = randomDirection += origin ?? agent.transform.position;
            agent.MoveTowards(randomLocation, speed);
            return true;
        }

        public static Rigidbody Wander(
            this Rigidbody agent,
            float radius,
            MonoBehaviour monoBehaviour,
            float speed,
            bool isContinues = true,
            float waitTime = 1,
            Func<bool> condition = null,
            bool useSameHeight = true
        )
        {
            if (isContinues)
                monoBehaviour.StartCoroutine(WanderCoroutine());
            else
                agent.SetRandomDestination(radius, speed * Time.deltaTime);

            IEnumerator WanderCoroutine()
            {
                Vector3 randomLocation = Random.insideUnitSphere * radius;
                if (useSameHeight)
                    randomLocation.SetY(agent.position);
                while (agent != null && condition != null ? condition() : true)
                {
                    if (agent.transform.HasReachedDestination(randomLocation))
                    {
                        yield return new WaitForSeconds(waitTime);
                        randomLocation = Random.insideUnitSphere * radius;
                        if (useSameHeight)
                            randomLocation.SetY(agent.position);
                    }
                    else
                        agent.MoveTowards(randomLocation, 1);

                    yield return null;
                }
            }

            return agent;
        }

        public static Rigidbody ContinuesFleeFromTargetWhile(
            this Rigidbody agent,
            Transform target,
            MonoBehaviour monoBehaviour,
            float speed,
            float fleeDistance = 10,
            Func<bool> condition = null
        )
        {
            if (agent == null || target == null)
                return null;

            monoBehaviour.StartCoroutine(FleeFromTargetCoroutine());

            IEnumerator FleeFromTargetCoroutine()
            {
                while (agent != null && target != null && condition != null ? condition() : true)
                {
                    Vector3 fleeDirection = (agent.transform.position - target.position).normalized;
                    Vector3 fleePosition = agent.transform.position + fleeDirection * fleeDistance;

                    agent.MoveTowards(fleePosition, speed * Time.deltaTime);

                    yield return null;
                }
            }

            return agent;
        }

        public static Rigidbody ContinuesPatrolWaypointsWhile(
            this Rigidbody agent,
            List<Transform> waypoints,
            float speed,
            MonoBehaviour monoBehaviour,
            bool followWaypointOrder = true,
            Func<bool> condition = null
        )
        {
            if (agent == null || waypoints == null || waypoints.Count == 0)
                return null;
            monoBehaviour.StartCoroutine(PatrolWaypointsCoroutine());

            IEnumerator PatrolWaypointsCoroutine()
            {
                int currentWaypointIndex = 0;

                while (agent != null && condition != null ? condition() : true)
                {
                    Transform currentWaypoint = waypoints[currentWaypointIndex];
                    agent.MoveTowards(currentWaypoint.position, speed * Time.deltaTime);

                    if (agent.transform.HasReachedDestination(currentWaypoint))
                    {
                        currentWaypointIndex = followWaypointOrder
                            ? (currentWaypointIndex + 1) % waypoints.Count
                            : Random.Range(0, waypoints.Count);
                    }

                    yield return null;
                }
            }

            return agent;
        }

        #endregion
    }
}
