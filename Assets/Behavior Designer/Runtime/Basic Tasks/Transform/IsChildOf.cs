using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

namespace BehaviorDesigner.Runtime.Tasks.Basic.UnityTransform
{
    [TaskCategory("Basic/Transform")]
    [TaskDescription("Returns Success if the transform is a child of the specified GameObject.")]
    public class IsChildOf : Conditional
    {
        [Tooltip("The interested transform")]
        public SharedTransform transformName;

        public override TaskStatus OnUpdate()
        {
            if (transform == null) {
                Debug.LogWarning("Transform is null");
                return TaskStatus.Failure;
            }

            return transform.IsChildOf(transformName.Value) ? TaskStatus.Success : TaskStatus.Failure;
        }

        public override void OnReset()
        {
            if (transformName != null) {
                transformName.Value = null;
            }
        }
    }
}