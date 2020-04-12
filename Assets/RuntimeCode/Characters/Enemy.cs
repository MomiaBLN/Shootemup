using System;
using UnityEngine;
using RuntimeCode.Motion;

namespace RuntimeCode.Characters
{
	public class Enemy : Character
	{
		[SerializeField] protected AgentTransformFollower agentTransformFollower;
		public AgentTransformFollower AgentTransformFollower => agentTransformFollower;

		protected override void Reset()
		{
			if (!TryGetComponent(out agentTransformFollower))
				throw new NullReferenceException();

			base.Reset();
		}

		public override void GetDamage()
		{
			Die();
		}
	}
}