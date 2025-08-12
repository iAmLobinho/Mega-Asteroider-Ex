using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace SABI
{
    public static class TransformExtensions
    {
        public static Transform ResetValues(this Transform transform)
        {
            transform.localPosition = Vector3.zero;
            transform.localRotation = Quaternion.identity;
            transform.localScale = Vector3.one;
            return transform;
        }

        #region LocalEulerAngle
        public static Transform SetLocalEulerAngles(
            this Transform transform,
            float? x = null,
            float? y = null,
            float? z = null
        )
        {
            var eulerAngles = transform.localEulerAngles;

            if (x.HasValue)
            {
                eulerAngles.x = x.Value;
            }

            if (y.HasValue)
            {
                eulerAngles.y = y.Value;
            }

            if (z.HasValue)
            {
                eulerAngles.z = z.Value;
            }

            transform.localEulerAngles = eulerAngles;
            return transform;
        }

        public static Transform AddLocalEulerAngles(
            this Transform transform,
            float? x = null,
            float? y = null,
            float? z = null
        )
        {
            var eulerAngles = transform.localEulerAngles;

            if (x.HasValue)
            {
                eulerAngles.x += x.Value;
            }

            if (y.HasValue)
            {
                eulerAngles.y += y.Value;
            }

            if (z.HasValue)
            {
                eulerAngles.z += z.Value;
            }

            transform.localEulerAngles = eulerAngles;
            return transform;
        }

        public static Transform SubtractLocalEulerAngles(
            this Transform transform,
            float? x = null,
            float? y = null,
            float? z = null
        )
        {
            var eulerAngles = transform.localEulerAngles;

            if (x.HasValue)
            {
                eulerAngles.x -= x.Value;
            }

            if (y.HasValue)
            {
                eulerAngles.y -= y.Value;
            }

            if (z.HasValue)
            {
                eulerAngles.z -= z.Value;
            }

            transform.localEulerAngles = eulerAngles;
            return transform;
        }

        public static Transform SetLocalEulerAngleX(this Transform transform, float x)
        {
            transform.localEulerAngles = transform.localEulerAngles.WithX(x);
            return transform;
        }

        public static Transform SetLocalEulerAngleY(this Transform transform, float y)
        {
            transform.localEulerAngles = transform.localEulerAngles.WithY(y);
            return transform;
        }

        public static Transform SetLocalEulerAngleZ(this Transform transform, float z)
        {
            transform.localEulerAngles = transform.localEulerAngles.WithZ(z);
            return transform;
        }

        public static Transform AddLocalEulerAngleX(this Transform transform, float x)
        {
            transform.localEulerAngles = transform.localEulerAngles.WithAddX(x);
            return transform;
        }

        public static Transform AddLocalEulerAngleY(this Transform transform, float y)
        {
            transform.localEulerAngles = transform.localEulerAngles.WithAddY(y);
            return transform;
        }

        public static Transform AddLocalEulerAngleZ(this Transform transform, float z)
        {
            transform.localEulerAngles = transform.localEulerAngles.WithAddZ(z);
            return transform;
        }

        public static Transform SubtractLocalEulerAngleX(this Transform transform, float x)
        {
            transform.localEulerAngles = transform.localEulerAngles.WithSubtractX(x);
            return transform;
        }

        public static Transform SubtractLocalEulerAngleY(this Transform transform, float y)
        {
            transform.localEulerAngles = transform.localEulerAngles.WithSubtractY(y);
            return transform;
        }

        public static Transform SubtractLocalEulerAngleZ(this Transform transform, float z)
        {
            transform.localEulerAngles = transform.localEulerAngles.WithSubtractZ(z);
            return transform;
        }
        #endregion

        #region EulerAngle
        public static Transform SetEulerAngles(
            this Transform transform,
            float? x = null,
            float? y = null,
            float? z = null
        )
        {
            var eulerAngles = transform.eulerAngles;

            if (x.HasValue)
            {
                eulerAngles.x = x.Value;
            }

            if (y.HasValue)
            {
                eulerAngles.y = y.Value;
            }

            if (z.HasValue)
            {
                eulerAngles.z = z.Value;
            }

            transform.eulerAngles = eulerAngles;
            return transform;
        }

        public static Transform AddEulerAngles(
            this Transform transform,
            float? x = null,
            float? y = null,
            float? z = null
        )
        {
            var eulerAngles = transform.eulerAngles;

            if (x.HasValue)
            {
                eulerAngles.x += x.Value;
            }

            if (y.HasValue)
            {
                eulerAngles.y += y.Value;
            }

            if (z.HasValue)
            {
                eulerAngles.z += z.Value;
            }

            transform.eulerAngles = eulerAngles;
            return transform;
        }

        public static Transform SubtractEulerAngles(
            this Transform transform,
            float? x = null,
            float? y = null,
            float? z = null
        )
        {
            var eulerAngles = transform.eulerAngles;

            if (x.HasValue)
            {
                eulerAngles.x -= x.Value;
            }

            if (y.HasValue)
            {
                eulerAngles.y -= y.Value;
            }

            if (z.HasValue)
            {
                eulerAngles.z -= z.Value;
            }

            transform.eulerAngles = eulerAngles;
            return transform;
        }

        public static Transform SetEulerAngleX(this Transform transform, float x)
        {
            transform.eulerAngles = transform.eulerAngles.WithX(x);
            return transform;
        }

        public static Transform SetEulerAngleY(this Transform transform, float y)
        {
            transform.eulerAngles = transform.eulerAngles.WithY(y);
            return transform;
        }

        public static Transform SetEulerAngleZ(this Transform transform, float z)
        {
            transform.eulerAngles = transform.eulerAngles.WithZ(z);
            return transform;
        }

        public static Transform AddEulerAngleX(this Transform transform, float x)
        {
            transform.eulerAngles = transform.eulerAngles.WithAddX(x);
            return transform;
        }

        public static Transform AddEulerAngleY(this Transform transform, float y)
        {
            transform.eulerAngles = transform.eulerAngles.WithAddY(y);
            return transform;
        }

        public static Transform AddEulerAngleZ(this Transform transform, float z)
        {
            transform.eulerAngles = transform.eulerAngles.WithAddZ(z);
            return transform;
        }

        public static Transform SubtractEulerAngleX(this Transform transform, float x)
        {
            transform.eulerAngles = transform.eulerAngles.WithSubtractX(x);
            return transform;
        }

        public static Transform SubtractEulerAngleY(this Transform transform, float y)
        {
            transform.eulerAngles = transform.eulerAngles.WithSubtractY(y);
            return transform;
        }

        public static Transform SubtractEulerAngleZ(this Transform transform, float z)
        {
            transform.eulerAngles = transform.eulerAngles.WithSubtractZ(z);
            return transform;
        }
        #endregion

        #region Position

        public static Transform SetPosition(
            this Transform transform,
            float? x = null,
            float? y = null,
            float? z = null
        )
        {
            var position = transform.position;

            if (x.HasValue)
            {
                position.x = x.Value;
            }

            if (y.HasValue)
            {
                position.y = y.Value;
            }

            if (z.HasValue)
            {
                position.z = z.Value;
            }

            transform.position = position;
            return transform;
        }

        public static Transform AddPosition(
            this Transform transform,
            float? x = null,
            float? y = null,
            float? z = null
        )
        {
            var position = transform.position;

            if (x.HasValue)
            {
                position.x += x.Value;
            }

            if (y.HasValue)
            {
                position.y += y.Value;
            }

            if (z.HasValue)
            {
                position.z += z.Value;
            }

            transform.position = position;
            return transform;
        }

        public static Transform SubtractPosition(
            this Transform transform,
            float? x = null,
            float? y = null,
            float? z = null
        )
        {
            var position = transform.position;

            if (x.HasValue)
            {
                position.x -= x.Value;
            }

            if (y.HasValue)
            {
                position.y -= y.Value;
            }

            if (z.HasValue)
            {
                position.z -= z.Value;
            }

            transform.position = position;
            return transform;
        }

        #region Set Position

        public static Transform SetPositionX(this Transform transform, float x)
        {
            transform.position = transform.position.WithX(x);
            return transform;
        }

        public static Transform SetPositionY(this Transform transform, float y)
        {
            transform.position = transform.position.WithY(y);
            return transform;
        }

        public static Transform SetPositionZ(this Transform transform, float z)
        {
            transform.position = transform.position.WithZ(z);
            return transform;
        }

        public static Transform SetPositionX(this Transform transform, Vector3 x)
        {
            transform.position = transform.position.WithX(x.x);
            return transform;
        }

        public static Transform SetPositionY(this Transform transform, Vector3 y)
        {
            transform.position = transform.position.WithY(y.y);
            return transform;
        }

        public static Transform SetPositionZ(this Transform transform, Vector3 z)
        {
            transform.position = transform.position.WithZ(z.z);
            return transform;
        }

        public static Transform SetPositionX(this Transform transform, Transform x)
        {
            transform.position = transform.position.WithX(x.position.x);
            return transform;
        }

        public static Transform SetPositionY(this Transform transform, Transform y)
        {
            transform.position = transform.position.WithY(y.position.y);
            return transform;
        }

        public static Transform SetPositionZ(this Transform transform, Transform z)
        {
            transform.position = transform.position.WithZ(z.position.z);
            return transform;
        }

        #endregion

        #region Set Local Position

        public static Transform SetLocalPositionX(this Transform transform, float x)
        {
            transform.localPosition = transform.localPosition.WithX(x);
            return transform;
        }

        public static Transform SetLocalPositionY(this Transform transform, float y)
        {
            transform.localPosition = transform.localPosition.WithY(y);
            return transform;
        }

        public static Transform SetLocalPositionZ(this Transform transform, float z)
        {
            transform.localPosition = transform.localPosition.WithZ(z);
            return transform;
        }

        public static Transform SetLocalPositionX(this Transform transform, Vector3 x)
        {
            transform.localPosition = transform.localPosition.WithX(x.x);
            return transform;
        }

        public static Transform SetLocalPositionY(this Transform transform, Vector3 y)
        {
            transform.localPosition = transform.localPosition.WithY(y.y);
            return transform;
        }

        public static Transform SetLocalPositionZ(this Transform transform, Vector3 z)
        {
            transform.localPosition = transform.localPosition.WithZ(z.z);
            return transform;
        }

        public static Transform SetLocalPositionX(this Transform transform, Transform x)
        {
            transform.localPosition = transform.localPosition.WithX(x.localPosition.x);
            return transform;
        }

        public static Transform SetLocalPositionY(this Transform transform, Transform y)
        {
            transform.localPosition = transform.localPosition.WithY(y.localPosition.y);
            return transform;
        }

        public static Transform SetLocalPositionZ(this Transform transform, Transform z)
        {
            transform.localPosition = transform.localPosition.WithZ(z.localPosition.z);
            return transform;
        }

        #endregion

        #region Set Euler Angles

        public static Transform SetEulerAnglesX(this Transform transform, float x)
        {
            transform.eulerAngles = transform.eulerAngles.WithX(x);
            return transform;
        }

        public static Transform SetEulerAnglesY(this Transform transform, float y)
        {
            transform.eulerAngles = transform.eulerAngles.WithY(y);
            return transform;
        }

        public static Transform SetEulerAnglesZ(this Transform transform, float z)
        {
            transform.eulerAngles = transform.eulerAngles.WithZ(z);
            return transform;
        }

        public static Transform SetEulerAnglesX(this Transform transform, Vector3 x)
        {
            transform.eulerAngles = transform.eulerAngles.WithX(x.x);
            return transform;
        }

        public static Transform SetEulerAnglesY(this Transform transform, Vector3 y)
        {
            transform.eulerAngles = transform.eulerAngles.WithY(y.y);
            return transform;
        }

        public static Transform SetEulerAnglesZ(this Transform transform, Vector3 z)
        {
            transform.eulerAngles = transform.eulerAngles.WithZ(z.z);
            return transform;
        }

        public static Transform SetEulerAnglesX(this Transform transform, Transform x)
        {
            transform.eulerAngles = transform.eulerAngles.WithX(x.eulerAngles.x);
            return transform;
        }

        public static Transform SetEulerAnglesY(this Transform transform, Transform y)
        {
            transform.eulerAngles = transform.eulerAngles.WithY(y.eulerAngles.y);
            return transform;
        }

        public static Transform SetEulerAnglesZ(this Transform transform, Transform z)
        {
            transform.eulerAngles = transform.eulerAngles.WithZ(z.eulerAngles.z);
            return transform;
        }

        #endregion

        #region Set Local Euler Angles

        public static Transform SetLocalEulerAnglesX(this Transform transform, float x)
        {
            transform.localEulerAngles = transform.localEulerAngles.WithX(x);
            return transform;
        }

        public static Transform SetLocalEulerAnglesY(this Transform transform, float y)
        {
            transform.localEulerAngles = transform.localEulerAngles.WithY(y);
            return transform;
        }

        public static Transform SetLocalEulerAnglesZ(this Transform transform, float z)
        {
            transform.localEulerAngles = transform.localEulerAngles.WithZ(z);
            return transform;
        }

        public static Transform SetLocalEulerAnglesX(this Transform transform, Vector3 x)
        {
            transform.localEulerAngles = transform.localEulerAngles.WithX(x.x);
            return transform;
        }

        public static Transform SetLocalEulerAnglesY(this Transform transform, Vector3 y)
        {
            transform.localEulerAngles = transform.localEulerAngles.WithY(y.y);
            return transform;
        }

        public static Transform SetLocalEulerAnglesZ(this Transform transform, Vector3 z)
        {
            transform.localEulerAngles = transform.localEulerAngles.WithZ(z.z);
            return transform;
        }

        public static Transform SetLocalEulerAnglesX(this Transform transform, Transform x)
        {
            transform.localEulerAngles = transform.localEulerAngles.WithX(x.localEulerAngles.x);
            return transform;
        }

        public static Transform SetLocalEulerAnglesY(this Transform transform, Transform y)
        {
            transform.localEulerAngles = transform.localEulerAngles.WithY(y.localEulerAngles.y);
            return transform;
        }

        public static Transform SetLocalEulerAnglesZ(this Transform transform, Transform z)
        {
            transform.localEulerAngles = transform.localEulerAngles.WithZ(z.localEulerAngles.z);
            return transform;
        }

        #endregion

        #region Set Local Scale
        public static Transform SetLocalScale(this Transform transform, float scale)
        {
            transform.localScale = new Vector3(scale, scale, scale);
            return transform;
        }

        public static Transform SetLocalScaleX(this Transform transform, float x)
        {
            transform.localScale = transform.localScale.WithX(x);
            return transform;
        }

        public static Transform SetLocalScaleY(this Transform transform, float y)
        {
            transform.localScale = transform.localScale.WithY(y);
            return transform;
        }

        public static Transform SetLocalScaleZ(this Transform transform, float z)
        {
            transform.localScale = transform.localScale.WithZ(z);
            return transform;
        }

        public static Transform SetLocalScaleX(this Transform transform, Vector3 x)
        {
            transform.localScale = transform.localScale.WithX(x.x);
            return transform;
        }

        public static Transform SetLocalScaleY(this Transform transform, Vector3 y)
        {
            transform.localScale = transform.localScale.WithY(y.y);
            return transform;
        }

        public static Transform SetLocalScaleZ(this Transform transform, Vector3 z)
        {
            transform.localScale = transform.localScale.WithZ(z.z);
            return transform;
        }

        public static Transform SetLocalScaleX(this Transform transform, Transform x)
        {
            transform.localScale = transform.localScale.WithX(x.localScale.x);
            return transform;
        }

        public static Transform SetLocalScaleY(this Transform transform, Transform y)
        {
            transform.localScale = transform.localScale.WithY(y.localScale.y);
            return transform;
        }

        public static Transform SetLocalScaleZ(this Transform transform, Transform z)
        {
            transform.localScale = transform.localScale.WithZ(z.localScale.z);
            return transform;
        }

        #endregion



        public static Transform AddPositionX(this Transform transform, float x)
        {
            transform.position = transform.position.WithAddX(x);
            return transform;
        }

        public static Transform AddPositionY(this Transform transform, float y)
        {
            transform.position = transform.position.WithAddY(y);
            return transform;
        }

        public static Transform AddPositionZ(this Transform transform, float z)
        {
            transform.position = transform.position.WithAddZ(z);
            return transform;
        }

        public static Transform SubtractPositionX(this Transform transform, float x)
        {
            transform.position = transform.position.WithSubtractX(x);
            return transform;
        }

        public static Transform SubtractPositionY(this Transform transform, float y)
        {
            transform.position = transform.position.WithSubtractY(y);
            return transform;
        }

        public static Transform SubtractPositionZ(this Transform transform, float z)
        {
            transform.position = transform.position.WithSubtractZ(z);
            return transform;
        }

        #endregion

        #region LocalPosition
        public static Transform SetLocalPosition(
            this Transform transform,
            float? x = null,
            float? y = null,
            float? z = null
        )
        {
            var localPosition = transform.localPosition;

            if (x.HasValue)
            {
                localPosition.x = x.Value;
            }

            if (y.HasValue)
            {
                localPosition.y = y.Value;
            }

            if (z.HasValue)
            {
                localPosition.z = z.Value;
            }

            transform.localPosition = localPosition;
            return transform;
        }

        public static Transform AddLocalPosition(
            this Transform transform,
            float? x = null,
            float? y = null,
            float? z = null
        )
        {
            var localPosition = transform.localPosition;

            if (x.HasValue)
            {
                localPosition.x += x.Value;
            }

            if (y.HasValue)
            {
                localPosition.y += y.Value;
            }

            if (z.HasValue)
            {
                localPosition.z += z.Value;
            }

            transform.localPosition = localPosition;
            return transform;
        }

        public static Transform SubtractLocalPosition(
            this Transform transform,
            float? x = null,
            float? y = null,
            float? z = null
        )
        {
            var localPosition = transform.localPosition;

            if (x.HasValue)
            {
                localPosition.x -= x.Value;
            }

            if (y.HasValue)
            {
                localPosition.y -= y.Value;
            }

            if (z.HasValue)
            {
                localPosition.z -= z.Value;
            }

            transform.localPosition = localPosition;
            return transform;
        }

        public static Transform AddLocalPositionX(this Transform transform, float x)
        {
            transform.localPosition = transform.localPosition.WithAddX(x);
            return transform;
        }

        public static Transform AddLocalPositionY(this Transform transform, float y)
        {
            transform.localPosition = transform.localPosition.WithAddY(y);
            return transform;
        }

        public static Transform AddLocalPositionZ(this Transform transform, float z)
        {
            transform.localPosition = transform.localPosition.WithAddZ(z);
            return transform;
        }

        public static Transform SubtractLocalPositionX(this Transform transform, float x)
        {
            transform.localPosition = transform.localPosition.WithSubtractX(x);
            return transform;
        }

        public static Transform SubtractLocalPositionY(this Transform transform, float y)
        {
            transform.localPosition = transform.localPosition.WithSubtractY(y);
            return transform;
        }

        public static Transform SubtractLocalPositionZ(this Transform transform, float z)
        {
            transform.localPosition = transform.localPosition.WithSubtractZ(z);
            return transform;
        }

        #endregion

        #region Scale

        public static Transform SetScale(
            this Transform transform,
            float? x = null,
            float? y = null,
            float? z = null
        )
        {
            var scale = transform.localScale;

            if (x.HasValue)
            {
                scale.x = x.Value;
            }

            if (y.HasValue)
            {
                scale.y = y.Value;
            }

            if (z.HasValue)
            {
                scale.z = z.Value;
            }

            transform.localScale = scale;
            return transform;
        }

        public static Transform AddScale(
            this Transform transform,
            float? x = null,
            float? y = null,
            float? z = null
        )
        {
            var scale = transform.localScale;

            if (x.HasValue)
            {
                scale.x += x.Value;
            }

            if (y.HasValue)
            {
                scale.y += y.Value;
            }

            if (z.HasValue)
            {
                scale.z += z.Value;
            }

            transform.localScale = scale;
            return transform;
        }

        public static Transform SubtractScale(
            this Transform transform,
            float? x = null,
            float? y = null,
            float? z = null
        )
        {
            var scale = transform.localScale;

            if (x.HasValue)
            {
                scale.x -= x.Value;
            }

            if (y.HasValue)
            {
                scale.y -= y.Value;
            }

            if (z.HasValue)
            {
                scale.z -= z.Value;
            }

            transform.localScale = scale;
            return transform;
        }

        public static Transform SetScale(this Transform transform, float UniformScaleValue) =>
            transform.SetScale(UniformScaleValue, UniformScaleValue, UniformScaleValue);

        public static Transform AddScale(this Transform transform, float UniformScaleValue) =>
            transform.AddScale(UniformScaleValue, UniformScaleValue, UniformScaleValue);

        public static Transform SubtractScale(this Transform transform, float UniformScaleValue) =>
            transform.SubtractScale(UniformScaleValue, UniformScaleValue, UniformScaleValue);

        public static Transform SetScaleX(this Transform transform, float x)
        {
            transform.localScale = transform.localScale.WithX(x);
            return transform;
        }

        public static Transform SetScaleY(this Transform transform, float y)
        {
            transform.localScale = transform.localScale.WithY(y);
            return transform;
        }

        public static Transform SetScaleZ(this Transform transform, float z)
        {
            transform.localScale = transform.localScale.WithZ(z);
            return transform;
        }

        public static Transform AddScaleX(this Transform transform, float x)
        {
            transform.localScale = transform.localScale.WithAddX(x);
            return transform;
        }

        public static Transform AddScaleY(this Transform transform, float y)
        {
            transform.localScale = transform.localScale.WithAddY(y);
            return transform;
        }

        public static Transform AddScaleZ(this Transform transform, float z)
        {
            transform.localScale = transform.localScale.WithAddZ(z);
            return transform;
        }

        public static Transform SubtractScaleX(this Transform transform, float x)
        {
            transform.localScale = transform.localScale.WithSubtractX(x);
            return transform;
        }

        public static Transform SubtractScaleY(this Transform transform, float y)
        {
            transform.localScale = transform.localScale.WithSubtractY(y);
            return transform;
        }

        public static Transform SubtractScaleZ(this Transform transform, float z)
        {
            transform.localScale = transform.localScale.WithSubtractZ(z);
            return transform;
        }

        #endregion

        #region Children

        public static Transform DestroyChildren(this Transform transform)
        {
            foreach (Transform child in transform)
                UnityEngine.Object.Destroy(child.gameObject);

            return transform;
        }

        public static Transform DetachChildren(this Transform transform)
        {
            foreach (Transform child in transform)
                child.SetParent(null);

            return transform;
        }

        public static Transform GetRandomChild(this Transform transform) =>
            transform.GetChild(Random.Range(0, transform.childCount));
        #endregion

        #region Distance

        public static float Distance(this Transform transform, Transform target) =>
            Vector3.Distance(transform.position, target.position);

        public static float Distance(this Transform transform, Vector3 target) =>
            Vector3.Distance(transform.position, target);

        public static float DistanceWithoutHeight(this Transform transform, Transform target) =>
            Vector3.Distance(transform.position.WithY(0), target.position.WithY(0));

        public static float DistanceWithoutHeight(this Transform transform, Vector3 target) =>
            Vector3.Distance(transform.position.WithY(0), target.WithY(0));

        #endregion

        #region Direction
        public static Vector3 DirectionTo(this Transform source, Transform target) =>
            (target.position - source.position).normalized;

        public static Vector3 DirectionFrom(this Transform target, Transform source) =>
            (source.position - target.position).normalized;

        public static Vector3 DirectionToIgnoringHeight(this Transform source, Transform target) =>
            (target.position.WithY(0) - source.position.WithY(0)).normalized;

        public static Vector3 DirectionFromIgnoringHeight(
            this Transform target,
            Transform source
        ) => (source.position.WithY(0) - target.position.WithY(0)).normalized;

        public static Vector3 DirectionTo(this Transform source, Vector3 target) =>
            (target - source.position).normalized;

        public static Vector3 DirectionFrom(this Transform target, Vector3 source) =>
            (source - target.position).normalized;

        public static Vector3 DirectionToIgnoringHeight(this Transform source, Vector3 target) =>
            (target.WithY(0) - source.position.WithY(0)).normalized;

        public static Vector3 DirectionFromIgnoringHeight(this Transform target, Vector3 source) =>
            (source.WithY(0) - target.position.WithY(0)).normalized;

        public static Vector3 back(this Transform v) => -v.forward;

        public static Vector3 left(this Transform v) => -v.right;

        public static Vector3 down(this Transform v) => -v.up;

        #endregion

        #region Simple Movements

        public static Transform MoveTowards(this Transform source, Transform target, float speed)
        {
            source.position = Vector3.MoveTowards(source.position, target.position, speed);
            return source;
        }

        public static Transform MoveTowards(this Transform source, Vector3 target, float speed)
        {
            source.position = Vector3.MoveTowards(source.position, target, speed);
            return source;
        }

        public static Transform ContinuesChaseTargetWhile(
            this Transform agent,
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

        public static bool HasReachedDestination(
            this Transform agent,
            Transform destination,
            float tolerence = 0.1f
        ) => agent.Distance(destination) < tolerence;

        public static bool HasReachedDestination(
            this Transform agent,
            Vector3 destination,
            float tolerence = 0.1f
        ) => agent.Distance(destination) < tolerence;

        public static bool SetRandomDestination(
            this Transform agent,
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
            this Transform agent,
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

        public static Transform Wander(
            this Transform agent,
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
                    if (agent.HasReachedDestination(randomLocation))
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

        public static Transform ContinuesFleeFromTargetWhile(
            this Transform agent,
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

        public static Transform ContinuesPatrolWaypointsWhile(
            this Transform agent,
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

                    if (agent.HasReachedDestination(currentWaypoint))
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

        #region LookAt

        public static Transform LookAtIgnoringY(this Transform source, Transform target)
        {
            source.LookAt(target.position.WithPosY(source));
            return source;
        }

        public static Transform LookAtIgnoringY(this Transform source, Vector3 target)
        {
            source.LookAt(target.WithPosY(source));
            return source;
        }

        #endregion

        #region Dot Product and Cross Product

        public static float Dot(this Transform v, Transform target) =>
            Vector3.Dot(v.forward, (target.position.WithY(0) - v.position.WithY(0)).normalized);

        public static float Dot(this Transform v, Vector3 target) =>
            Vector3.Dot(v.forward, (target.WithY(0) - v.position.WithY(0)).normalized);

        public static Vector3 Cross(this Transform v, Transform target) =>
            Vector3.Cross(v.forward, (target.position.WithY(0) - v.position.WithY(0)).normalized);

        public static Vector3 Cross(this Transform v, Vector3 target) =>
            Vector3.Cross(v.forward, (target.WithY(0) - v.position.WithY(0)).normalized);

        #endregion

        #region Position in world space and local space

        public static Vector3 WorldSpacePositionToLocalSpace(
            this Transform transform,
            Vector3 position
        )
        {
            Matrix4x4 worldToLocal = Matrix4x4
                .TRS(transform.position, transform.rotation, Vector3.one)
                .inverse;
            return worldToLocal.MultiplyPoint3x4(position);
        }

        public static Vector3 LocalSpacePositionToWorldSpace(
            this Transform transform,
            Vector3 position
        )
        {
            Matrix4x4 localToWorld = Matrix4x4.TRS(
                transform.position,
                transform.rotation,
                Vector3.one
            );
            return localToWorld.MultiplyPoint3x4(position);
        }

        #endregion
    }
}
