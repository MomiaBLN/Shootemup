using System.Collections;
using System;
using UnityEngine;

namespace RuntimeCode.Characters
{
	public abstract class TriggerDetector<T> : MonoBehaviour where T : MonoBehaviour
	{
		private void OnTriggerEnter(Collider other)
		{
			T detectedObject = other.GetComponentInParent<T>();

			if (!detectedObject)
				throw new InvalidOperationException();

			ReactToObjectDetection(detectedObject);
		}

		protected abstract void ReactToObjectDetection(T detectedObject);

		private void OnTriggerExit(Collider other)
		{
			T detectedObject = other.GetComponentInParent<T>();

			if (!detectedObject)
				throw new InvalidOperationException();

			ReactToObjectExited(detectedObject);
		}

		protected abstract void ReactToObjectExited(T detectedObject);
	}
}