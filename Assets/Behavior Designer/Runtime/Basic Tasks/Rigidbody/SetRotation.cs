using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

namespace BehaviorDesigner.Runtime.Tasks.Basic.UnityRigidbody
{
    [TaskCategory("Basic/Rigidbody")]
    [TaskDescription("Stores the rotation of the Rigidbody. Returns Success.")]
    public class SetRotation : Action
    {
        [Tooltip("The rotation of the Rigidbody")]
        public SharedQuaternion rotation;

        public override TaskStatus OnUpdate()
        {
            if (rigidbody == null) {
                Debug.LogWarning("Rigidbody is null");
                return TaskStatus.Failure;
            }

            rigidbody.rotation = rotation.Value;

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