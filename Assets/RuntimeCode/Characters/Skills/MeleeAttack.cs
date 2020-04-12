using UnityEngine;

namespace RuntimeCode.Characters.Skills
{
	[CreateAssetMenu(menuName ="Skills/Melee")]
	public class MeleeAttack : Skill
	{
		[SerializeField] protected string AttackTriggerName;

		public override void Use(Character user, Character receiver = null)
		{
			user.Animator.SetTrigger(AttackTriggerName);
			receiver.GetDamage();
		}
	}
}