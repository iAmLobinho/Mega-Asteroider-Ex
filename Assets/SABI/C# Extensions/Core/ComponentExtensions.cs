using UnityEngine;

namespace SABI
{
    public static class ComponentExtensions
    {
        public static T AddComponent<T>(this Component component)
            where T : Component => component.gameObject.AddComponent<T>();

        public static T GetOrAddComponent<T>(this Component component)
            where T : Component
        {
            if (!component.TryGetComponent<T>(out var attachedComponent))
                attachedComponent = component.AddComponent<T>();

            return attachedComponent;
        }

        public static bool HasComponent<T>(this Component component)
            where T : Component => component.TryGetComponent<T>(out _);

        public static void DestroyComponent<T>(this Component component)
            where T : Component
        {
            if (component.TryGetComponent<T>(out var componentToDestroy))
                Object.Destroy(componentToDestroy);
        }

        public static bool TryGetComponentInParent<T>(
            this Component component,
            out T componentFound,
            bool includeInactive = false
        )
            where T : Component
        {
            componentFound = component.gameObject.GetComponentInParent<T>(includeInactive);
            return componentFound != null;
        }

        public static bool TryGetComponentInChildren<T>(
            this Component component,
            out T componentFound,
            bool includeInactive = false
        )
            where T : Component
        {
            componentFound = component.gameObject.GetComponentInChildren<T>(includeInactive);
            return componentFound != null;
        }
    }
}
