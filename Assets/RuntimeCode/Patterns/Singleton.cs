using UnityEngine;

namespace ICV.Basics.Patterns
{
    /// <summary>
    /// Inherit from this base class to create a singleton.
    /// e.g. public class MyClassName : Singleton<MyClassName> {}
    /// </summary>
    public abstract class Singleton<T> : MonoBehaviour where T : MonoBehaviour
    {
        // Check to see if we're about to be destroyed.
        private static bool m_ShuttingDown = false;
        private static bool m_BeingDestroyed = false;
        private static object m_Lock = new object();
        private static T m_Instance;

        /// <summary>
        /// Access singleton instance through this propriety.
        /// </summary>
        public static T Instance
        {
            get
            {
                if (m_BeingDestroyed)
                {
#if LOGS_ON
                    Debug.LogWarning($"[Singleton] Instance '{typeof(T)}' already destroyed. Returning null.");
#endif
                    return null;
                }

                lock (m_Lock)
                {
                    if (m_Instance == null && !m_ShuttingDown)
                    {
                        // Search for existing instance.
                        m_Instance = (T)FindObjectOfType(typeof(T));

                        // Create new instance if one doesn't already exist.
                        if (m_Instance == null)
                        {
                            // Need to create a new GameObject to attach the singleton to.
                            var singletonObject = new GameObject();
                            m_Instance = singletonObject.AddComponent<T>();
                            singletonObject.name = $"{typeof(T).ToString()} (Singleton)";

                            // Make instance persistent.
                            DontDestroyOnLoad(singletonObject);
                        }

                        (m_Instance as Singleton<T>).OnFirstTimeUsed();
                    }

                    return m_Instance;
                }
            }
        }

        protected abstract void OnFirstTimeUsed();
        
        private void OnApplicationQuit()
        {
            m_ShuttingDown = true;
        }

        private void OnDestroy()
        {
            m_BeingDestroyed = true;
        }
    }
}