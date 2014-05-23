using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

namespace BehaviorDesigner.Runtime.Tasks.Basic.UnityTransform
{
    [TaskCategory("Basic/Transform")]
    [TaskDescription("Sets the parent of the Transform. Returns Success.")]
    public class SetParent : Action
    {
        [Tooltip("The parent of the Transform")]
        public SharedTransform parent;

        public override TaskStatus OnUpdate()
        {
            if (transform == null) {
                Debug.LogWarning("Transform is null");
                return TaskStatus.Failure;
            }

            transform.parent = parent.Value;

            return TaskStatus.Success;
        }

        public override void OnReset()
        {
            if (parent != null) {
                parent.Value = null;
            }
        }
    }
}