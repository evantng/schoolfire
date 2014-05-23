using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

namespace BehaviorDesigner.Runtime.Tasks.Basic.UnityTransform
{
    [TaskCategory("Basic/Transform")]
    [TaskDescription("Applies a rotation. Returns Success.")]
    public class RotateAround : Action
    {
        [Tooltip("Point to rotate around")]
        public SharedVector3 point;
        [Tooltip("Axis to rotate around")]
        public SharedVector3 axis;
        [Tooltip("Amount to rotate")]
        public SharedFloat angle;

        public override TaskStatus OnUpdate()
        {
            if (transform == null) {
                Debug.LogWarning("Transform is null");
                return TaskStatus.Failure;
            }

            transform.RotateAround(point.Value, axis.Value, angle.Value);

            return TaskStatus.Success;
        }

        public override void OnReset()
        {
            if (point != null) {
                point.Value = Vector3.zero;
            }
            if (axis != null) {
                axis.Value = Vector3.zero;
            }
            if (angle != null) {
                angle.Value = 0;
            }
        }
    }
}