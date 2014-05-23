using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

namespace BehaviorDesigner.Runtime.Tasks.Basic.UnityRigidbody
{
    [TaskCategory("Basic/Rigidbody")]
    [TaskDescription("Rotates the Rigidbody to the specified rotation. Returns Success.")]
    public class MoveRotation : Action
    {
        [Tooltip("The new rotation of the Rigidbody")]
        public SharedQuaternion rotation;

        public override TaskStatus OnUpdate()
        {
            if (rigidbody == null) {
                Debug.LogWarning("Rigidbody is null");
                return TaskStatus.Failure;
            }

            rigidbody.MoveRotation(rotation.Value);

            return TaskStatus.Success;
        }

        public override void OnReset()
        {
            if (rotation != null) {
                rotation.Value = Quaternion.identity;
            }
        }
    }
}