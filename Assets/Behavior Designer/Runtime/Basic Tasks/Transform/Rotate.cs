using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

namespace BehaviorDesigner.Runtime.Tasks.Basic.UnityTransform
{
    [TaskCategory("Basic/Transform")]
    [TaskDescription("Applies a rotation. Returns Success.")]
    public class Rotate : Action
    {
        [Tooltip("Amount to rotate")]
        public SharedVector3 eulerAngles;
        [Tooltip("Specifies which axis the rotation is relative to")]
        public Space relativeTo = Space.Self;

        public override TaskStatus OnUpdate()
        {
            if (transform == null) {
                Debug.LogWarning("Transform is null");
                return TaskStatus.Failure;
            }

            transform.Rotate(eulerAngles.Value, relativeTo);

            return TaskStatus.Success;
        }

        public override void OnReset()
        {
            if (eulerAngles != null) {
                eulerAngles.Value = Vector3.zero;
            }
            relativeTo = Space.Self;
        }
    }
}