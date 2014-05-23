using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

namespace BehaviorDesigner.Runtime.Tasks.Basic.UnityCapsuleCollider
{
    [TaskCategory("Basic/CapsuleCollider")]
    [TaskDescription("Sets the center of the CapsuleCollider. Returns Success.")]
    public class SetCenter : Action
    {
        [Tooltip("The center of the CapsuleCollider")]
        public SharedVector3 center;

        private CapsuleCollider capsuleCollider;

        public override void OnAwake()
        {
            capsuleCollider = gameObject.GetComponent<CapsuleCollider>();
        }

        public override TaskStatus OnUpdate()
        {
            if (capsuleCollider == null) {
                Debug.LogWarning("CapsuleCollider is null");
                return TaskStatus.Failure;
            }

            capsuleCollider.center = center.Value;

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