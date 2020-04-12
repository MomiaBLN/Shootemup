using UnityEngine;
using System.Collections;
using RuntimeCode.Delegates;
using RuntimeCode.Interfaces;

namespace RuntimeCode.Waitings
{
	public class Refresher : MonoBehaviour, IInitializable
	{
		[SerializeField] protected WaitingAsset waitingDefinition;
		protected YieldInstruction waiting;

		public event StandardDelegate Refresh;

		public bool IsInitialized => throw new System.NotImplementedException();

		public void Initialize()
		{
			waiting = waitingDefinition.GetYield();
			StartCoroutine(RefreshDestination());
		}

		private void OnEnable()
		{
			Initialize();
		}

		protected IEnumerator RefreshDestination()
		{
			do
			{
				Refresh?.Invoke();
				yield return waiting;
			} while (enabled);
		}
	}
}