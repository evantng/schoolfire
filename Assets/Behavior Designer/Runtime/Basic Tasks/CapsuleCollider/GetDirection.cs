using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

namespace BehaviorDesigner.Runtime.Tasks.Basic.UnityCapsuleCollider
{
    [TaskCategory("Basic/CapsuleCollider")]
    [TaskDescription("Stores the direction of the CapsuleCollider. Returns Success.")]
    public class GetDirection : Action
    {
        [Tooltip("The direction of the CapsuleCollider")]
        public SharedInt storeValue;

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

            storeValue.Value = capsuleCollider.direction;

            return TaskStatus.Success;
        }

        public override void OnReset()
        {
            if (storeValue != null) {
                storeValue.Value = 0;
            }
        }
    }
}