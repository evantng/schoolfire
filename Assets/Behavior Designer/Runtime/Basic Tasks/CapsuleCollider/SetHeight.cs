using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

namespace BehaviorDesigner.Runtime.Tasks.Basic.UnityCapsuleCollider
{
    [TaskCategory("Basic/CapsuleCollider")]
    [TaskDescription("Sets the height of the CapsuleCollider. Returns Success.")]
    public class SetHeight : Action
    {
        [Tooltip("The height of the CapsuleCollider")]
        public SharedFloat direction;

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

            capsuleCollider.height = direction.Value;

            return TaskStatus.Success;
        }

        public override void OnReset()
        {
            if (direction != null) {
                direction.Value = 0;
            }
        }
    }
}