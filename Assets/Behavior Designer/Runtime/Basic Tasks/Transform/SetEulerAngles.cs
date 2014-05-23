using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

namespace BehaviorDesigner.Runtime.Tasks.Basic.UnityTransform
{
    [TaskCategory("Basic/Transform")]
    [TaskDescription("Sets the euler angles of the Transform. Returns Success.")]
    public class SetEulerAngles : Action
    {
        [Tooltip("The euler angles of the Transform")]
        public SharedVector3 eulerAngles;

        public override TaskStatus OnUpdate()
        {
            if (transform == null) {
                Debug.LogWarning("Transform is null");
                return TaskStatus.Failure;
            }

            transform.eulerAngles = eulerAngles.Value;

            return TaskStatus.Success;
        }

        public override void OnReset()
        {
            if (eulerAngles != null) {
                eulerAngles.Value = Vector3.zero;
            }
        }
    }
}