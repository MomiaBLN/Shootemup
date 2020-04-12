using UnityEngine;

namespace RuntimeCode.Characters.Skills
{
	[CreateAssetMenu(menuName = "Skills/Granade")]
	public class GranadeAttack : Skill
	{
		[SerializeField] protected string GranadeTriggerName;
		[SerializeField] protected float distance = 4f, radius = 1.5f;
		[SerializeField] protected LayerMask enemiesHitBoxLayer;

		public override void Use(Character user, Character receiver = null)
		{
			user.Animator.SetTrigger(GranadeTriggerName);

			Vector3 explotionPosition = user.transform.TransformPoint(Vector3.forward * distance);

			Collider[] colliders = Physics.OverlapSphere(explotionPosition, radius, enemiesHitBoxLayer);

			foreach (var item in colliders)
			{
				if (!item.TryGetComponent(out HitBox hitBox))
				{
					continue;
				}
				hitBox.Character.GetDamage();
			}
		}
	}
}