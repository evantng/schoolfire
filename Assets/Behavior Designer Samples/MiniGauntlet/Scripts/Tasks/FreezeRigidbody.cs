using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;

namespace BehaviorDesigner.Runtime.Samples
{
    [TaskCategory("MiniGauntlet")]
    [TaskDescription("Sets the agent's rigidbody constraints to FreezeAll")]
    public class FreezeRigidbody : Action
    {
        public override TaskStatus OnUpdate()
        {
            rigidbody.constraints = RigidbodyConstraints.FreezeAll;
            return TaskStatus.Success;
        }
    }
}