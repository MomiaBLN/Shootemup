using System;
using UnityEngine;

namespace RuntimeCode
{
    [RequireComponent(typeof(Animator))]
    public class IKAttacher : MonoBehaviour
    {
        [SerializeField] protected Animator animator;
        [SerializeField] protected int layerIndex = 1;
        [SerializeField] protected AvatarIKGoal iKToBeAttached;

        [SerializeField, Range(0f, 1f)] protected float positionWeight = 1f;
        [SerializeField, Range(0f, 1f)] protected float rotationWeight = 1f;
        [SerializeField] protected Transform objectToAttach = null;

        protected void Start()
        {
            if (!animator && !TryGetComponent(out animator)) throw new NullReferenceException("Not Animator found.");
        }

        private void OnDisable()
        {
            ResetWeight();
        }

        protected void OnAnimatorIK(int layerIndex)
        {
            if (this.layerIndex != layerIndex) return;

            SetIKPosition(objectToAttach.position, positionWeight);
            SetIKRotation(objectToAttach.rotation, rotationWeight);
        }

        protected void SetIKPosition(Vector3 position, float weight)
        {
            animator.SetIKPositionWeight(iKToBeAttached, weight);
            animator.SetIKPosition(iKToBeAttached, position);
        }

        protected void SetIKRotation(Quaternion rotation, float weight)
        {
            animator.SetIKRotationWeight(iKToBeAttached, weight);
            animator.SetIKRotation(iKToBeAttached, rotation);
        }

        protected void ResetWeight()
        {
            animator.SetIKPositionWeight(iKToBeAttached, 0);
            animator.SetIKRotationWeight(iKToBeAttached, 0);
        }
    }
}