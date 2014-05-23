using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

namespace BehaviorDesigner.Runtime.Tasks.Basic.UnityTransform
{
    [TaskCategory("Basic/Transform")]
    [TaskDescription("Finds a child transform by name. Returns Success.")]
    public class FindChild : Action
    {
        [Tooltip("The transform name to find")]
        public SharedString transformName;
        [Tooltip("The object found by name")]
        public SharedTransform storeValue;

        public override TaskStatus OnUpdate()
        {
            if (transform == null) {
                Debug.LogWarning("Transform is null");
                return TaskStatus.Failure;
            }

            storeValue.Value = transform.FindChild(transformName.Value);

            return TaskStatus.Success;
        }

        public override void OnReset()
        {
            if (transformName != null) {
                transformName.Value = null;
            }
            if (storeValue != null) {
                storeValue.Value = null;
            }
        }
    }
}