using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

namespace BehaviorDesigner.Runtime.Tasks.Basic.UnityTransform
{
    [TaskCategory("Basic/Transform")]
    [TaskDescription("Sets the local euler angles of the Transform. Returns Success.")]
    public class SetLocalEulerAngles : Action
    {
        [Tooltip("The local euler angles of the Transform")]
        public SharedVector3 localEulerAngles;

        public override TaskStatus OnUpdate()
        {
            if (transform == null) {
                Debug.LogWarning("Transform is null");
                return TaskStatus.Failure;
            }

            transform.localEulerAngles = localEulerAngles.Value;

            return TaskStatus.Success;
        }

        public override void OnReset()
        {
            if (localEulerAngles != null) {
                localEulerAngles.Value = Vector3.zero;
            }
        }
    }
}