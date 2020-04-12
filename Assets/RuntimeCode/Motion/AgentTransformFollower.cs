using System;
using UnityEngine;
using RuntimeCode.Waitings;

namespace RuntimeCode.Motion
{
	public class AgentTransformFollower : AgentDestinationSetter
	{
		[SerializeField] protected Refresher refresher;
		[SerializeField] protected Transform target;

		public void ChangeTarget(Transform target)
		{
			this.target = target;
			if (!enabled)
				enabled = true;
		}

		public override void Initialize()
		{
			if (refresher == null && !TryGetComponent(out refresher))
				throw new NullReferenceException();

			base.Initialize();
		}

		protected void SetTargetPositionAsDestination()
		{
			SetDestination(target.position);
		}

		private void OnEnable()
		{
			refresher.Refresh += SetTargetPositionAsDestination;
		}

		private void OnDisable()
		{
			refresher.Refresh -= SetTargetPositionAsDestination;
		}
	}
}