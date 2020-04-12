using UnityEngine;

namespace RuntimeCode.Characters.Skills
{
	[CreateAssetMenu(menuName = "Skills/Shot")]
	public class ShotAttack : Skill
	{
		[SerializeField] protected string ShotTriggerName;
		[SerializeField] protected float distance = 4f;
		[SerializeField] protected LayerMask enemiesHitBoxLayer;

		public override void Use(Character user, Character receiver = null)
		{
			user.Animator.SetTrigger(ShotTriggerName);
			if (Physics.Raycast(user.transform.position, user.transform.forward, out RaycastHit hit, distance, enemiesHitBoxLayer))
			{
				if (!hit.collider.TryGetComponent(out HitBox hitBox))
				{
					return;
				}

				hitBox.Character.GetDamage();
			}
		}
	}
}