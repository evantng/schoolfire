using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

namespace BehaviorDesigner.Runtime.Tasks.Basic.UnityTransform
{
    [TaskCategory("Basic/Transform")]
    [TaskDescription("Stores the euler angles of the Transform. Returns Success.")]
    public class GetEulerAngles : Action
    {
        [Tooltip("The euler angles of the Transform")]
        public SharedVector3 storeValue;

        public override TaskStatus OnUpdate()
        {
            if (transform == null) {
                Debug.LogWarning("Transform is null");
                return TaskStatus.Failure;
            }

            storeValue.Value = transform.eulerAngles;

            return TaskStatus.Success;
        }

        public override void OnReset()
        {
            if (storeValue != null) {
                storeValue.Value = Vector3.zero;
            }
        }
    }
}