using UnityEngine;

namespace RuntimeCode.Motion
{
    public class AgentDestinationSetter : NavMeshAgentUser
    {
        public override void Initialize()
        {
            isInitialized = true;
        }

        public void SetDestination(Vector3 destination)
        {
            agent.destination = destination;
        }
    }
}