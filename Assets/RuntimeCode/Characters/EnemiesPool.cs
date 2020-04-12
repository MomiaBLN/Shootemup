using UnityEngine;
using RuntimeCode.Patterns;
using System.Collections.Generic;

namespace RuntimeCode.Characters
{
	[CreateAssetMenu(menuName = "Pool/Enemies")]
	public class EnemiesPool : ObjectsPool<Enemy>
	{
	    [SerializeField] protected List<Enemy> enemiesPrefabs;

		protected override Enemy Prefab => enemiesPrefabs[Random.Range(0, enemiesPrefabs.Count)];

#if UNITY_EDITOR
		private void OnValidate()
		{
			foreach (var item in enemiesPrefabs)
			{
				item.gameObject.SetActive(false);
			}
		}

		[ContextMenu("CheckGetInstance")]
		protected void CheckGetInstance()
		{
			GetInstance();
		}
#endif

	}
}