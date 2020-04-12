using UnityEngine;
using UnityEngine.Events;

namespace RuntimeCode
{
	public class EndOfAnimationCallback : MonoBehaviour
	{
		[SerializeField] UnityEvent OnAnimationFinished;

		[SerializeField] protected WaitUntilTheEndOfAnimation waiting;

		public void WaitForTheEndOfLaunchedAnimation()
		{
			StartCoroutine(waiting.WaitUntilAnimationFinished(() =>
			{
				OnAnimationFinished?.Invoke();
			}));
		}
	}
}