using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

namespace BehaviorDesigner.Runtime.Tasks.Basic.UnityRigidbody
{
    [TaskCategory("Basic/Rigidbody")]
    [TaskDescription("Sets the is kinematic value of the Rigidbody. Returns Success.")]
    public class SetIsKinematic : Action
    {
        [Tooltip("The is kinematic value of the Rigidbody")]
        public SharedBool isKinematic;

        public override TaskStatus OnUpdate()
        {
            if (rigidbody == null) {
                Debug.LogWarning("Rigidbody is null");
                return TaskStatus.Failure;
            }

            rigidbody.isKinematic = isKinematic.Value;

            return TaskStatus.Success;
        }

        public override void OnReset()
        {
            if (isKinematic != null) {
                isKinematic.Value = false;
            }
        }
    }
}