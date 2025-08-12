using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

namespace SABI
{
    public static class NavMeshAgentExtensions
    {
        public static NavMeshAgent IncreaseAngularSpeed(
            this NavMeshAgent agent,
            float angularSpeed = 1000
        )
        {
            agent.angularSpeed = angularSpeed;
            return agent;
        }

        public static bool HasReachedDestination(this NavMeshAgent agent)
        {
            if (agent == null)
                return false;
            return !agent.pathPending && agent.remainingDistance <= agent.stoppingDistance;
        }

        public static bool HasReachedDestination(
            this NavMeshAgent agent,
            Transform destination,
            float tolerence = 0.1f
        ) => agent.transform.Distance(destination) < tolerence;

        public static bool HasReachedDestination(
            this NavMeshAgent agent,
            Vector3 destination,
            float tolerence = 0.1f
        ) => agent.transform.Distance(destination) < tolerence;

        public static bool SetRandomDestination(
            this NavMeshAgent agent,
            float radius,
            Vector3? origin = null,
            int areaMask = NavMesh.AllAreas
        )
        {
            if (agent == null)
                return false;

            for (int i = 0; i < 10; i++)
            {
                Vector3 randomDirection = Random.insideUnitSphere * radius;
                randomDirection += origin ?? agent.transform.position;
                if (NavMesh.SamplePosition(randomDirection, out NavMeshHit hit, radius, areaMask))
                {
                    agent.SetDestination(hit.position);
                    return true;
                }
            }

            return false;
        }

        public static NavMeshAgent SmoothSpeedChange(
            this NavMeshAgent agent,
            MonoBehaviour monobehaviour,
            float targetSpeed,
            float duration
        )
        {
            if (agent == null)
                return null;
            float startSpeed = agent.speed;
            float elapsedTime = 0f;
            monobehaviour.StartCoroutine(Routine());
            IEnumerator Routine()
            {
                while (elapsedTime < duration)
                {
                    agent.speed = Mathf.Lerp(startSpeed, targetSpeed, elapsedTime / duration);
                    elapsedTime += Time.deltaTime;
                    yield return null;
                }
                agent.speed = targetSpeed;
            }
            return agent;
        }

        public static NavMeshAgent PatrolDestination(
            this NavMeshAgent agent,
            List<Vector3> patrolPath,
            float tolerance = 1f
        )
        {
            if (agent == null || patrolPath == null || patrolPath.Count == 0)
                return null;

            Vector3 currentWaypoint = patrolPath[0];
            if (Vector3.Distance(agent.transform.position, currentWaypoint) <= tolerance)
            {
                int nextIndex = (patrolPath.IndexOf(currentWaypoint) + 1) % patrolPath.Count;
                currentWaypoint = patrolPath[nextIndex];
            }

            agent.SetDestination(currentWaypoint);
            return agent;
        }

        /// <summary>
        /// Call it from a loop
        /// </summary>
        public static NavMeshAgent PatrolDestination(
            this NavMeshAgent agent,
            List<Transform> patrolPath,
            float tolerance = 1f
        )
        {
            if (agent == null || patrolPath == null || patrolPath.Count == 0)
                return null;

            Transform currentWaypoint = patrolPath[0];
            if (Vector3.Distance(agent.transform.position, currentWaypoint.position) <= tolerance)
            {
                int nextIndex = (patrolPath.IndexOf(currentWaypoint) + 1) % patrolPath.Count;
                currentWaypoint = patrolPath[nextIndex];
            }

            agent.SetDestination(currentWaypoint.position);
            return agent;
        }

        public static NavMeshAgent AddKnockBack(
            this NavMeshAgent agent,
            Transform target,
            float force
        )
        {
            agent.ResetPath();
            Vector3 selfPosition = agent.transform.position;
            Vector3 targetPosition = target.position;
            Vector3 knockBackDirection = target.position.WithY(0) - selfPosition.WithY(0);
            agent.SetDestination(selfPosition + knockBackDirection.normalized * force);
            return agent;
        }

        public static NavMeshAgent SetTemporarySpeed(
            this NavMeshAgent agent,
            MonoBehaviour monoBehaviour,
            float temporarySpeed,
            float duration
        )
        {
            if (agent == null || !agent.isActiveAndEnabled)
                return null;
            monoBehaviour.StartCoroutine(TemporarySpeedCoroutine(agent, temporarySpeed, duration));

            IEnumerator TemporarySpeedCoroutine(
                NavMeshAgent agent,
                float temporarySpeed,
                float duration
            )
            {
                float originalSpeed = agent.speed;
                agent.speed = temporarySpeed;

                yield return new WaitForSeconds(duration);

                if (agent != null && agent.isActiveAndEnabled)
                {
                    agent.speed = originalSpeed;
                }
            }

            return agent;
        }

        public static NavMeshAgent Wander(
            this NavMeshAgent agent,
            MonoBehaviour monoBehaviour,
            Func<float> radius,
            bool isContinues = true,
            Func<float> waitTime = null,
            Func<bool> loopWhile = null,
            Action OnStartMoving = null,
            Action OnStopMoving = null,
            Action OnUpdate = null
        )
        {
            if (agent == null || !agent.isActiveAndEnabled)
                return null;

            if (isContinues)
                monoBehaviour.StartCoroutine(WanderCoroutine());
            else
                agent.SetRandomDestination(radius());

            IEnumerator WanderCoroutine()
            {
                while (agent != null && agent.isActiveAndEnabled && (loopWhile?.Invoke() ?? true))
                {
                    if (agent.SetRandomDestination(radius()))
                    {
                        OnStartMoving?.Invoke();
                        yield return new WaitUntil(() => agent.HasReachedDestination());
                        OnStopMoving?.Invoke();
                    }
                    yield return new WaitForSeconds(waitTime?.Invoke() ?? 1);
                    OnUpdate?.Invoke();
                }
            }

            return agent;
        }

        #region Chase

        public static NavMeshAgent Chase(
            this NavMeshAgent agent,
            MonoBehaviour monoBehaviour,
            Func<Transform> target,
            Func<float> minDistanceKeep,
            Func<float> maxDistanceKeep,
            Func<float> delayBetweenSettingDestination = null,
            Func<bool> loopWhile = null,
            Func<float> distanceToPlayer = null,
            Action OnUpdate = null
        )
        {
            if (agent == null || !agent.isActiveAndEnabled || target == null)
                return null;
            monoBehaviour.StartCoroutine(ChaseTargetCoroutine());

            IEnumerator ChaseTargetCoroutine()
            {
                Vector3 selfPosition = agent.transform.position;

                while (
                    agent != null
                    && agent.isActiveAndEnabled
                    && target != null
                    && (loopWhile?.Invoke() ?? true)
                )
                {
                    WaitForSeconds delay = new WaitForSeconds(
                        delayBetweenSettingDestination == null
                            ? 0
                            : delayBetweenSettingDestination()
                    );
                    float distance =
                        distanceToPlayer == null
                            ? agent.transform.Distance(target())
                            : distanceToPlayer();

                    if (minDistanceKeep == null || maxDistanceKeep == null)
                    {
                        agent.SetDestination(target().position);
                    }
                    else
                    {
                        if (distance < minDistanceKeep())
                        {
                            Vector3 directionToMoveWhenTooCloseToPlayer = (
                                target().position - selfPosition
                            ).normalized;
                            Vector3 positionToMove =
                                selfPosition
                                + (
                                    directionToMoveWhenTooCloseToPlayer
                                    * -1
                                    * (maxDistanceKeep() - distance)
                                );
                            NavMeshPath path = new NavMeshPath();
                            if (agent.CalculatePath(positionToMove, path))
                                agent.SetDestination(positionToMove);
                        }
                        else
                        {
                            agent.SetDestination(target().position);
                        }
                    }

                    if (delayBetweenSettingDestination == null)
                        yield return null;
                    else
                        yield return delay;

                    OnUpdate?.Invoke();
                }
            }

            return agent;
        }

        #endregion


        public static NavMeshAgent Flee(
            this NavMeshAgent agent,
            MonoBehaviour monoBehaviour,
            Func<Transform> target = null,
            Func<float> fleeDistance = null,
            Func<bool> loopWhile = null,
            Action OnUpdate = null
        )
        {
            if (agent == null || !agent.isActiveAndEnabled || target == null)
                return null;
            monoBehaviour.StartCoroutine(FleeFromTargetCoroutine());

            IEnumerator FleeFromTargetCoroutine()
            {
                while (
                    agent != null
                    && agent.isActiveAndEnabled
                    && target != null
                    && (loopWhile?.Invoke() ?? true)
                )
                {
                    float fleeDistanceValue = fleeDistance == null ? 10 : fleeDistance();
                    Vector3 fleeDirection = (
                        agent.transform.position - target().position
                    ).normalized;
                    Vector3 fleePosition =
                        agent.transform.position + fleeDirection * fleeDistanceValue;

                    if (
                        NavMesh.SamplePosition(
                            fleePosition,
                            out NavMeshHit hit,
                            fleeDistanceValue,
                            NavMesh.AllAreas
                        )
                    )
                    {
                        agent.SetDestination(hit.position);
                    }
                    yield return null;
                    OnUpdate?.Invoke();
                }
            }

            return agent;
        }

        public static NavMeshAgent Patroll(
            this NavMeshAgent agent,
            MonoBehaviour monoBehaviour,
            Func<List<Transform>> waypoints,
            float tolerance = 0.1f,
            Func<float> waitTime = null,
            Func<bool> followWaypointOrder = null,
            Func<bool> loopWhile = null,
            Action OnStartMoving = null,
            Action OnStopMoving = null,
            Action OnUpdate = null
        )
        {
            monoBehaviour.StartCoroutine(PatrolWaypointsCoroutine());

            IEnumerator PatrolWaypointsCoroutine()
            {
                int currentWaypointIndex = 0;

                while (agent != null && agent.isActiveAndEnabled && (loopWhile?.Invoke() ?? true))
                {
                    Transform currentWaypoint = waypoints()[currentWaypointIndex];
                    agent.SetDestination(currentWaypoint.position);
                    OnStartMoving?.Invoke();
                    yield return new WaitUntil(
                        () => agent.HasReachedDestination(currentWaypoint.position, tolerance)
                    );
                    OnStopMoving?.Invoke();
                    yield return new WaitForSeconds(waitTime?.Invoke() ?? 1);
                    currentWaypointIndex =
                        (followWaypointOrder != null ? followWaypointOrder() : true)
                            ? (currentWaypointIndex + 1) % waypoints().Count
                            : Random.Range(0, waypoints().Count);
                    OnUpdate?.Invoke();
                }
            }

            return agent;
        }

        public static NavMeshAgent ContinuesAvoidObstaclesWhile(
            this NavMeshAgent agent,
            LayerMask obstacleMask,
            float avoidanceRadius,
            MonoBehaviour monoBehaviour,
            Func<bool> condition = null
        )
        {
            if (agent == null || !agent.isActiveAndEnabled)
                return null;
            monoBehaviour.StartCoroutine(AvoidObstaclesCoroutine());

            IEnumerator AvoidObstaclesCoroutine()
            {
                while (agent != null && agent.isActiveAndEnabled && (condition?.Invoke() ?? true))
                {
                    Collider[] obstacles = Physics.OverlapSphere(
                        agent.transform.position,
                        avoidanceRadius,
                        obstacleMask
                    );
                    if (obstacles.Length > 0)
                    {
                        Vector3 avoidanceDirection = Vector3.zero;
                        foreach (Collider obstacle in obstacles)
                        {
                            avoidanceDirection += (
                                agent.transform.position - obstacle.transform.position
                            ).normalized;
                        }
                        avoidanceDirection /= obstacles.Length;

                        Vector3 newDestination =
                            agent.transform.position + avoidanceDirection * avoidanceRadius;
                        if (
                            NavMesh.SamplePosition(
                                newDestination,
                                out NavMeshHit hit,
                                avoidanceRadius,
                                NavMesh.AllAreas
                            )
                        )
                        {
                            agent.SetDestination(hit.position);
                        }
                    }
                    yield return null;
                }
            }

            return agent;
        }

        // public static void WaitAtDestination(this NavMeshAgent agent,Func<bool> condition, float waitTime, MonoBehaviour monoBehaviour)
        // {
        //     if (agent == null || !agent.isActiveAndEnabled) return;
        //     monoBehaviour.StartCoroutine(WaitAtDestinationCoroutine());
        //
        //     IEnumerator WaitAtDestinationCoroutine()
        //     {
        //         agent.isStopped = true;
        //         yield return new WaitForSeconds(waitTime);
        //         if (agent != null && agent.isActiveAndEnabled)
        //         {
        //             agent.isStopped = false;
        //         }
        //     }
        // }
    }
}
