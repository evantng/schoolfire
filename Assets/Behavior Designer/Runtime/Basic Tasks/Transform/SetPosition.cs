using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

namespace BehaviorDesigner.Runtime.Tasks.Basic.UnityTransform
{
    [TaskCategory("Basic/Transform")]
    [TaskDescription("Sets the position of the Transform. Returns Success.")]
    public class SetPosition : Action
    {
        [Tooltip("The position of the Transform")]
        public SharedVector3 position;

        public override TaskStatus OnUpdate()
        {
            if (transform == null) {
                Debug.LogWarning("Transform is null");
                return TaskStatus.Failure;
            }

            transform.position = position.Value;

            return TaskStatus.Success;
        }

        public override void OnReset()
        {
            if (position != null) {
                position.Value = Vector3.zero;
            }
        }
    }
}