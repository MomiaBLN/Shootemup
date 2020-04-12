using UnityEngine;

namespace RuntimeCode.Characters
{
	[RequireComponent(typeof(Collider))]
	public class HitBox : MonoBehaviour
	{
		[SerializeField] protected Character character;
		public Character Character => character;

		[SerializeField] protected Collider collider;

		private void OnEnable()
		{
			collider.enabled = true;
		}

		private void OnDisable()
		{
			collider.enabled = false;
		}
	}
}