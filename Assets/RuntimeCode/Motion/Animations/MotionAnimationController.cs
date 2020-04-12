using System;
using UnityEngine;
using RuntimeCode.Waitings;

namespace RuntimeCode.Motion.Animation
{
    public class MotionAnimationController : NavMeshAgentUser
    {
        [SerializeField] protected Refresher refresher;
        [SerializeField] protected Animator animator;
        [SerializeField] protected string floatParameter = "Speed";
        protected float inverseMaxSpeed;

        protected void SetDefault()
        {
            animator.SetFloat(floatParameter, 0f);
            inverseMaxSpeed = 1f / agent.speed;
        }

        protected void SetParameter()
        {
            float normalizedSpeed = agent.velocity.magnitude * inverseMaxSpeed;
            animator.SetFloat(floatParameter, normalizedSpeed);
        }

        public override void Initialize()
        {
            if (!animator && !TryGetComponent(out animator)) throw new NullReferenceException("Not Animator found.");
            
            SetDefault();

            if (refresher == null && !TryGetComponent(out refresher))
                throw new NullReferenceException();

            isInitialized = true;
        }

        private void OnEnable()
        {
            refresher.Refresh += SetParameter;
        }

        private void OnDisable()
        {
            refresher.Refresh -= SetParameter;
        }
    }
}