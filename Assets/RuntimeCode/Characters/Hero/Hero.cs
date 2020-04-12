using System;
using UnityEngine;
using RuntimeCode.Motion;
using RuntimeCode.Characters.Skills;

namespace RuntimeCode.Characters
{
	public class Hero : Character
	{
		[SerializeField] protected AgentDirectionSetter agentDirectionSetter;
		public AgentDirectionSetter AgentDirectionSetter => agentDirectionSetter;

		[SerializeField] protected int maxPointsLife;
		protected int currentPointsLife;

		[SerializeField] protected Skill[] skills;

		protected override void Reset()
		{
			if (!TryGetComponent(out agentDirectionSetter))
				throw new NullReferenceException();

			base.Reset();
		}

		private void OnEnable()
		{
			currentPointsLife = maxPointsLife;
		}

		public void Shot()
		{
			Attack(null);
		}

		public void UseSkill(int index)
		{
			if (index < 0 || index >= skills.Length) throw new IndexOutOfRangeException();

			skills[index].Use(this);
		}

		public override void GetDamage()
		{
			currentPointsLife = Mathf.Clamp(currentPointsLife - 1, 0, maxPointsLife);
			if (currentPointsLife <= 0)
				Die();
		}
	}
}