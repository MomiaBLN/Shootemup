using System;
using UnityEngine;
using RuntimeCode.Motion;
using RuntimeCode.Waitings;

namespace RuntimeCode.Characters
{
	[RequireComponent(typeof(Refresher))]
	public class LookAtTransform : NavMeshAgentUser
	{
		[SerializeField] protected Refresher refresher;
		protected Transform transformToLook;

		protected float angularSpeed;

		public override void Initialize()
		{
			if (refresher == null && !TryGetComponent(out refresher))
				throw new NullReferenceException();
			angularSpeed = agent.angularSpeed;

			if (transformToLook != null)
			{
				agent.angularSpeed = 0f;
			}

			isInitialized = true;
		}

		public void LookAt(Transform transformToLook)
		{
			bool wasLookingAt = this.transformToLook != null;

			this.transformToLook = transformToLook;

			if (!wasLookingAt)
			{
				refresher.Refresh += RefreshRotation;
				refresher.enabled = true;

				if (isInitialized)
					Initialize();
			}
		}

		public void StopLookingAt()
		{
			agent.angularSpeed = angularSpeed;
			refresher.Refresh -= RefreshRotation;
			refresher.enabled = false;
			transformToLook = null;
		}

		protected void RefreshRotation()
		{
			Vector3 lookPos = transformToLook.position - transform.position;
			lookPos.y = 0;
			Quaternion rotation = Quaternion.LookRotation(lookPos);
			transform.rotation = Quaternion.Slerp(transform.rotation, rotation, angularSpeed);

		}
	}
}