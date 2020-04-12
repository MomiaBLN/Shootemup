using UnityEngine;

namespace RuntimeCode.Motion
{
	public class AgentDirectionSetter : AgentDestinationSetter
    {
        public override void Initialize()
        {
            isInitialized = true;
        }

        public void SetDirection(Vector3 direction)
        {
            Vector3 destination = transform.position + direction;

            SetDestination(destination);
        }
    }
}