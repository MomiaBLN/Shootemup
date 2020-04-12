using UnityEngine;
using ICV.Basics.Patterns;
using RuntimeCode.Extensions;

namespace RuntimeCode.Characters
{
    public class EnemiesSpawner : Singleton<EnemiesSpawner>
    {
        [SerializeField] protected Hero hero;
        [SerializeField] protected EnemiesPool enemiesPool;

        [SerializeField] protected int firstEnemiesWave = 4;

        [SerializeField] protected BoxCollider instantiationLimits;
        protected Bounds InstantiationBounds => instantiationLimits.bounds;

        protected override void OnFirstTimeUsed()
        {
            for (int i = 0; i < firstEnemiesWave; i++)
            {
                Enemy instance = enemiesPool.GetInstance();
                instance.AgentTransformFollower.ChangeTarget(hero.transform);
                instance.LookAtTransform.LookAt(hero.transform);
                instance.transform.position = Vector3Extensions.GetRandomVector3(InstantiationBounds);
                instance.transform.parent = transform;
                instance.gameObject.SetActive(true);
            }
        }

        private void OnEnable()
        {
            if (!Instance.isActiveAndEnabled)
                throw new System.Exception();
        }
    }
}