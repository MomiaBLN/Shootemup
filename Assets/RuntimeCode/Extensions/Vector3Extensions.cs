using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RuntimeCode.Extensions
{
	public class Vector3Extensions : MonoBehaviour
	{
		public static Vector3 GetRandomVector3(Bounds bounds)
		{
			return GetRandomVector3(bounds.min, bounds.max);
		}

		public static Vector3 GetRandomVector3(Vector3 min, Vector3 max)
		{
			return new Vector3(Random.Range(min.x, max.x), Random.Range(min.y, max.y), Random.Range(min.z, max.z));
		}
	}
}