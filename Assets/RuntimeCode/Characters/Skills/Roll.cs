using System;
using UnityEngine;
using System.Collections;
using RuntimeCode.Motion;

namespace RuntimeCode.Characters.Skills
{
	[CreateAssetMenu(menuName = "Skills/Roll")]
	public class Roll : Skill
	{
		[SerializeField] protected string RollTriggerName;
		[SerializeField] protected WaitUntilTheEndOfAnimation waiting;
		[SerializeField] protected float distance;

		private int avoidancePriority = 0;

		public override void Use(Character user, Character receiver = null)
		{
			AgentDestinationSetter destinationSetter = user.GetComponent<AgentDestinationSetter>();

			avoidancePriority = destinationSetter.Agent.avoidancePriority;
			user.Animator.SetTrigger(RollTriggerName);

			user.StartCoroutine(waiting.WaitUntilAnimationFinished(() =>
			{
				destinationSetter.Agent.avoidancePriority = avoidancePriority;
				user.HitBox.enabled = true;
			}));
			
			destinationSetter.Agent.avoidancePriority = 0;
			destinationSetter.SetDestination(user.transform.TransformPoint(Vector3.forward * distance));
			user.HitBox.enabled = false;
		}
	}
}