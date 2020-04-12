using UnityEngine;

namespace RuntimeCode.Waitings
{
	[CreateAssetMenu(menuName = "Waiting/Seconds")]
	public class SecondsWaiting : WaitingAsset
	{
		[SerializeField] protected float secondsToWait = 1f;

		public override YieldInstruction GetYield() => new WaitForSeconds(secondsToWait);
	}
}