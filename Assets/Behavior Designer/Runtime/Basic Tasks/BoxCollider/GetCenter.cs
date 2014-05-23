using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

namespace BehaviorDesigner.Runtime.Tasks.Basic.UnityBoxCollider
{
    [TaskCategory("Basic/BoxCollider")]
    [TaskDescription("Stores the center of the BoxCollider. Returns Success.")]
    public class GetCenter : Action
    {
        [Tooltip("The center of the BoxCollider")]
        public SharedVector3 storeValue;

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

            storeValue.Value = boxCollider.center;

            return TaskStatus.Success;
        }

        public override void OnReset()
        {
            if (storeValue != null) {
                storeValue.Value = Vector3.zero;
            }
        }
    }
}