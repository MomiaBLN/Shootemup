using System;
using UnityEngine;
using UnityEngine.Events;
using RuntimeCode.Motion.Animation;
using RuntimeCode.Characters.Skills;

namespace RuntimeCode.Characters
{
	[RequireComponent(typeof(MotionAnimationController))]
	public abstract class Character : MonoBehaviour
	{
		[SerializeField] protected Animator animator;
		public Animator Animator => animator;

		[SerializeField] protected MotionAnimationController motionAnimationController;
		public MotionAnimationController MotionAnimationController => motionAnimationController;

		[SerializeField] protected LookAtTransform lookAtTransform;
		public LookAtTransform LookAtTransform => lookAtTransform;

		[SerializeField] protected HitBox hitBox;
		public HitBox HitBox => hitBox;

		[SerializeField] protected Skill baseAttack;

		protected virtual void Reset()
		{
			if (!TryGetComponent(out motionAnimationController))
				throw new NullReferenceException();

			if (!TryGetComponent(out lookAtTransform))
				throw new NullReferenceException();
		}

		public void Attack(Character receiver)
		{
			baseAttack.Use(this, receiver);
		}

		public abstract void GetDamage();
		protected void Die()
		{
			OnCharacterDied?.Invoke();
		}

		[SerializeField] UnityEvent OnCharacterDied;
	}
}