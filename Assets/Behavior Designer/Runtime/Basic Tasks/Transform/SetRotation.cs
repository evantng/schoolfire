using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

namespace BehaviorDesigner.Runtime.Tasks.Basic.UnityTransform
{
    [TaskCategory("Basic/Transform")]
    [TaskDescription("Sets the rotation of the Transform. Returns Success.")]
    public class SetRotation : Action
    {
        [Tooltip("The rotation of the Transform")]
        public SharedQuaternion rotation;

        public override TaskStatus OnUpdate()
        {
            if (transform == null) {
                Debug.LogWarning("Transform is null");
                return TaskStatus.Failure;
            }

            transform.rotation = rotation.Value;

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