using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

namespace BehaviorDesigner.Runtime.Tasks.Basic.UnityTransform
{
    [TaskCategory("Basic/Transform")]
    [TaskDescription("Rotates the transform so the forward vector points at worldPosition. Returns Success.")]
    public class LookAt : Action
    {
        [Tooltip("Point to look at")]
        public SharedVector3 worldPosition;
        [Tooltip("Vector specifying the upward direction")]
        public Vector3 worldUp;

        public override TaskStatus OnUpdate()
        {
            if (transform == null) {
                Debug.LogWarning("Transform is null");
                return TaskStatus.Failure;
            }

            transform.LookAt(worldPosition.Value, worldUp);

            return TaskStatus.Success;
        }

        public override void OnReset()
        {
            if (worldPosition != null) {
                worldPosition.Value = Vector3.up;
            }
            worldUp = Vector3.up;
        }
    }
}