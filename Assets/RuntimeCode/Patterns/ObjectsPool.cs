using UnityEngine;
using System.Linq;
using System.Collections.Generic;

namespace RuntimeCode.Patterns
{
	public abstract class ObjectsPool<T> : ScriptableObject where T : MonoBehaviour
	{
		protected abstract T Prefab { get; }

#if UNITY_EDITOR
		private void OnValidate()
		{
			if (Prefab.gameObject.activeSelf)
				Prefab.gameObject.SetActive(false);
		}

		private void OnEnable()
		{
			currentInstances.Clear();
		}
#endif

		protected List<T> currentInstances = new List<T>();

		public T GetInstance()
		{
			return currentInstances.FirstOrDefault(instance => !instance.gameObject.activeSelf) ?? Instantiate();
		}

		public T Instantiate()
		{
			T instance = Instantiate(Prefab);

			currentInstances.Add(instance);

			return instance;
		}
	}
}