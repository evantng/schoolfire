using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

namespace BehaviorDesigner.Runtime.Tasks.Basic.UnityRigidbody
{
    [TaskCategory("Basic/Rigidbody")]
    [TaskDescription("Returns Success if the Rigidbody is kinematic, otherwise Failure.")]
    public class IsKinematic : Conditional
    {
        public override TaskStatus OnUpdate()
        {
            if (rigidbody == null) {
                Debug.LogWarning("Rigidbody is null");
                return TaskStatus.Failure;
            }

            return rigidbody.isKinematic ? TaskStatus.Success : TaskStatus.Failure;
        }
    }
}