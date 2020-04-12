using UnityEngine;

namespace RuntimeCode.Waitings
{
	[CreateAssetMenu(menuName = "Waiting/Frame")]
	public class FrameWaiting : WaitingAsset
	{
		public override YieldInstruction GetYield() => null;
	}
}