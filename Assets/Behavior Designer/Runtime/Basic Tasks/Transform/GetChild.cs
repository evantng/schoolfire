using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

namespace BehaviorDesigner.Runtime.Tasks.Basic.UnityTransform
{
    [TaskCategory("Basic/Transform")]
    [TaskDescription("Stores the transform child at the specified index. Returns Success.")]
    public class GetChild : Action
    {
        [Tooltip("The index of the child")]
        public SharedInt index;
        [Tooltip("The child of the Transform")]
        public SharedTransform storeValue;

        public override TaskStatus OnUpdate()
        {
            if (transform == null) {
                Debug.LogWarning("Transform is null");
                return TaskStatus.Failure;
            }

            storeValue.Value = transform.GetChild(index.Value);

            return TaskStatus.Success;
        }

        public override void OnReset()
        {
            if (index != null) {
                index.Value = 0;
            }
            if (storeValue != null) {
                storeValue.Value = null;
            }
        }
    }
}