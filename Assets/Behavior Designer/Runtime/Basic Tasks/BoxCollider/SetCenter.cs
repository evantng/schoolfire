using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

namespace BehaviorDesigner.Runtime.Tasks.Basic.UnityBoxCollider
{
    [TaskCategory("Basic/BoxCollider")]
    [TaskDescription("Sets the center of the BoxCollider. Returns Success.")]
    public class SetCenter : Action
    {
        [Tooltip("The center of the BoxCollider")]
        public SharedVector3 center;

        private BoxCollider boxCollider;

        public override void OnAwake()
        {
            boxCollider = gameObject.GetComponent<BoxCollider>();
        }

        public override TaskStatus OnUpdate()
        {
            if (boxCollider == null) {
                Debug.LogWarning("BoxCollider is null");
                return TaskStatus.Failure;
            }

            boxCollider.center = center.Value;

            return TaskStatus.Success;
        }

        public override void OnReset()
        {
            if (center != null) {
                center.Value = Vector3.zero;
            }
        }
    }
}