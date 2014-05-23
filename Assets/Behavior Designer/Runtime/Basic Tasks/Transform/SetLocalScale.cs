using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

namespace BehaviorDesigner.Runtime.Tasks.Basic.UnityTransform
{
    [TaskCategory("Basic/Transform")]
    [TaskDescription("Sets the local scale of the Transform. Returns Success.")]
    public class SetLocalScale : Action
    {
        [Tooltip("The local scale of the Transform")]
        public SharedVector3 localScale;

        public override TaskStatus OnUpdate()
        {
            if (transform == null) {
                Debug.LogWarning("Transform is null");
                return TaskStatus.Failure;
            }

            transform.localScale = localScale.Value;

            return TaskStatus.Success;
        }

        public override void OnReset()
        {
            if (localScale != null) {
                localScale.Value = Vector3.zero;
            }
        }
    }
}