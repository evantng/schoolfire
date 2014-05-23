using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

namespace BehaviorDesigner.Runtime.Tasks.Basic.UnityTransform
{
    [TaskCategory("Basic/Transform")]
    [TaskDescription("Moves the transform in the direction and distance of translation. Returns Success.")]
    public class Translate : Action
    {
        [Tooltip("Move direction and distance")]
        public SharedVector3 translation;
        [Tooltip("Specifies which axis the rotation is relative to")]
        public Space relativeTo = Space.Self;

        public override TaskStatus OnUpdate()
        {
            if (transform == null) {
                Debug.LogWarning("Transform is null");
                return TaskStatus.Failure;
            }

            transform.Translate(translation.Value, relativeTo);

            return TaskStatus.Success;
        }

        public override void OnReset()
        {
            if (translation != null) {
                translation.Value = Vector3.zero;
            }
            relativeTo = Space.Self;
        }
    }
}