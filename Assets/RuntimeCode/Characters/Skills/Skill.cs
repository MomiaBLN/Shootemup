using UnityEngine;

namespace RuntimeCode.Characters.Skills
{
	public abstract class Skill : ScriptableObject
	{
		public abstract void Use(Character user, Character receiver = null);
	}
}