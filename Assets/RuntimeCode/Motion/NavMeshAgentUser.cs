using System;
using UnityEngine;
using UnityEngine.AI;
using RuntimeCode.Interfaces;

namespace RuntimeCode.Motion
{
	[RequireComponent(typeof(NavMeshAgent))]
	public abstract class NavMeshAgentUser : MonoBehaviour, IInitializable
	{
		protected NavMeshAgent agent;
		public NavMeshAgent Agent => agent;

		protected bool isInitialized;
		public bool IsInitialized => isInitialized;
		public abstract void Initialize();

		protected bool IsPlacedOnNavMesh => agent.Warp(transform.position);

		private void Awake()
		{
			if (!TryGetComponent(out agent)) throw new NullReferenceException("Not Animator found.");

			if (!IsPlacedOnNavMesh) throw new NotSupportedException(string.Format("{0} is not placed on NavMesh. It can not be used.", gameObject.name));

			Initialize();
		}
	}
}