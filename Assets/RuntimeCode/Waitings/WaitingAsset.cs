using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RuntimeCode.Waitings
{
	public abstract class WaitingAsset : ScriptableObject
	{
		/// <summary>
		/// Returns a new instance of its yield instruction.
		/// </summary>
		/// <returns></returns>
		public abstract YieldInstruction GetYield();
	}
}