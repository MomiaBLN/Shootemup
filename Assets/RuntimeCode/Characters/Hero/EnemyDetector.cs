using System;
using UnityEngine;
using UnityEngine.Events;
using RuntimeCode.Waitings;
using RuntimeCode.UnityEvents;
using System.Collections.Generic;

namespace RuntimeCode.Characters
{
	public class EnemyDetector : TriggerDetector<Enemy>
	{
		protected List<Enemy> enemiesInRange = new List<Enemy>();
		protected Enemy closerEnemy;

		[SerializeField] protected Refresher refresher;
		[SerializeField] protected SphereCollider colliderDetector;

		public void OnEnable()
		{
			if (refresher == null && !TryGetComponent(out refresher))
				throw new NullReferenceException();
		}

		protected override void ReactToObjectDetection(Enemy detectedObject)
		{
			enemiesInRange.Add(detectedObject);

			if (enemiesInRange.Count == 1)
			{
				refresher.Refresh += LookAtCloserEnemy;
				refresher.enabled = true;
			}
		}

		public TransformUnityEvent OnLookAtTargetChanged;

		private void LookAtCloserEnemy()
		{
			int closerEnemyIndex = -1;
			float minSqrDistance = colliderDetector.radius * colliderDetector.radius;

			Vector3 position = transform.position;

			for (int i = 0; i < enemiesInRange.Count; i++)
			{
				float sqrDistance = (position - enemiesInRange[i].transform.position).sqrMagnitude;

				if (sqrDistance < minSqrDistance)
				{
					minSqrDistance = sqrDistance;
					closerEnemyIndex = i;
				}
			}

			if (closerEnemyIndex >= 0 && closerEnemy != enemiesInRange[closerEnemyIndex])
			{
				closerEnemy = enemiesInRange[closerEnemyIndex];
				OnLookAtTargetChanged?.Invoke(closerEnemy.transform);
			}
		}

		public UnityEvent OnStopLookingAt;

		protected override void ReactToObjectExited(Enemy detectedObject)
		{
			enemiesInRange.Remove(detectedObject);

			if (enemiesInRange.Count == 0)
			{
				refresher.Refresh -= LookAtCloserEnemy;
				refresher.enabled = false;

				OnStopLookingAt?.Invoke();
			}
		}
	}
}