using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

namespace BehaviorDesigner.Runtime.Tasks.Basic.UnityRigidbody
{
    [TaskCategory("Basic/Transform")]
    [TaskDescription("Stores the position of the Rigidbody. Returns Success.")]
    public class GetPosition : Action
    {
        [Tooltip("The position of the Rigidbody")]
        public SharedVector3 storeValue;

        public override TaskStatus OnUpdate()
        {
            if (rigidbody == null) {
                Debug.LogWarning("Rigidbody is null");
                return TaskStatus.Failure;
            }

            storeValue.Value = rigidbody.position;

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