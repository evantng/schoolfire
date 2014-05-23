using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

namespace BehaviorDesigner.Runtime.Tasks.Basic.UnityBoxCollider
{
    [TaskCategory("Basic/BoxCollider")]
    [TaskDescription("Sets the size of the BoxCollider. Returns Success.")]
    public class SetSize : Action
    {
        [Tooltip("The size of the BoxCollider")]
        public SharedVector3 size;

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

            boxCollider.size = size.Value;

            return TaskStatus.Success;
        }

        public override void OnReset()
        {
            if (size != null) {
                size.Value = Vector3.zero;
            }
        }
    }
}