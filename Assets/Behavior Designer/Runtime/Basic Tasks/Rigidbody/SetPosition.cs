using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

namespace BehaviorDesigner.Runtime.Tasks.Basic.UnityRigidbody
{
    [TaskCategory("Basic/Rigidbody")]
    [TaskDescription("Sets the position of the Rigidbody. Returns Success.")]
    public class SetPosition : Action
    {
        [Tooltip("The position of the Rigidbody")]
        public SharedVector3 position;

        public override TaskStatus OnUpdate()
        {
            if (rigidbody == null) {
                Debug.LogWarning("Rigidbody is null");
                return TaskStatus.Failure;
            }

            rigidbody.position = position.Value;

            return TaskStatus.Success;
        }

        public override void OnReset()
        {
            if (position != null) {
                position.Value = Vector3.zero;
            }
        }
    }
}