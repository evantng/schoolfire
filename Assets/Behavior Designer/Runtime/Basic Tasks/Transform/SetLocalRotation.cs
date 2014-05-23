using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

namespace BehaviorDesigner.Runtime.Tasks.Basic.UnityTransform
{
    [TaskCategory("Basic/Transform")]
    [TaskDescription("Sets the local rotation of the Transform. Returns Success.")]
    public class SetLocalRotation : Action
    {
        [Tooltip("The local rotation of the Transform")]
        public SharedQuaternion localRotation;

        public override TaskStatus OnUpdate()
        {
            if (transform == null) {
                Debug.LogWarning("Transform is null");
                return TaskStatus.Failure;
            }

            transform.localRotation = localRotation.Value;

            return TaskStatus.Success;
        }

        public override void OnReset()
        {
            if (localRotation != null) {
                localRotation.Value = Quaternion.identity;
            }
        }
    }
}