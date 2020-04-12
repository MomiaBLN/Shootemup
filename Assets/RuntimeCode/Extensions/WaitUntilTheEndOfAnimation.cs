using System;
using UnityEngine;
using System.Collections;

namespace RuntimeCode
{
	[Serializable]
	public class WaitUntilTheEndOfAnimation
	{
		[SerializeField] protected AnimationClip clip;

		public IEnumerator WaitUntilAnimationFinished(Action callback)
		{
			yield return new WaitForSeconds(clip.length);

			callback?.Invoke();
		}
	}
}