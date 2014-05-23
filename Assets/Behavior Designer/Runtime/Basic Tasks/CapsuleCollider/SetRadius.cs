using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

namespace BehaviorDesigner.Runtime.Tasks.Basic.UnityCapsuleCollider
{
    [TaskCategory("Basic/CapsuleCollider")]
    [TaskDescription("Sets the radius of the CapsuleCollider. Returns Success.")]
    public class SetRadius : Action
    {
        [Tooltip("The radius of the CapsuleCollider")]
        public SharedFloat radius;
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

            capsuleCollider.radius = radius.Value;

            return TaskStatus.Success;
        }

        public override void OnReset()
        {
            if (radius != null) {
                radius.Value = 0;
            }
        }
    }
}