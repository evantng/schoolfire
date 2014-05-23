using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

namespace BehaviorDesigner.Runtime.Tasks.Basic.UnityRigidbody
{
    [TaskCategory("Basic/Rigidbody")]
    [TaskDescription("Sets the constraints of the Rigidbody. Returns Success.")]
    public class SetConstraints : Action
    {
        [Tooltip("The constraints of the Rigidbody")]
        public RigidbodyConstraints constraints = RigidbodyConstraints.None;

        public override TaskStatus OnUpdate()
        {
            if (rigidbody == null) {
                Debug.LogWarning("Rigidbody is null");
                return TaskStatus.Failure;
            }

            rigidbody.constraints = constraints;

            return TaskStatus.Success;
        }

        public override void OnReset()
        {
            constraints = RigidbodyConstraints.None;
        }
    }
}