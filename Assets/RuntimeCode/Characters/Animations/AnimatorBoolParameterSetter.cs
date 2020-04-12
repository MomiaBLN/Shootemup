using System;
using UnityEngine;

namespace RuntimeCode.Characters.Animations
{
	[RequireComponent(typeof(Animator))]
	public class AnimatorBoolParameterSetter : MonoBehaviour
	{
		[SerializeField] protected Animator animator;
		[SerializeField] protected string booleanParameterName;

		public void Awake()
		{
			if (!animator && !TryGetComponent(out animator)) throw new NullReferenceException("Not Animator found.");
		}

		public void SetBoolean(bool value)
		{
			animator.SetBool(booleanParameterName, value);
		}
	}
}