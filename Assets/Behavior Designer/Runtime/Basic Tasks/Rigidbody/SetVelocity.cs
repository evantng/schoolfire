using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

namespace BehaviorDesigner.Runtime.Tasks.Basic.UnityRigidbody
{
    [TaskCategory("Basic/Rigidbody")]
    [TaskDescription("Sets the velocity of the Rigidbody. Returns Success.")]
    public class SetVelocity : Action
    {
        [Tooltip("The velocity of the Rigidbody")]
        public SharedVector3 velocity;

        public override TaskStatus OnUpdate()
        {
            if (rigidbody == null) {
                Debug.LogWarning("Rigidbody is null");
                return TaskStatus.Failure;
            }

            rigidbody.velocity = velocity.Value;

            return TaskStatus.Success;
        }

        public override void OnReset()
        {
            if (velocity != null) {
                velocity.Value = Vector3.zero;
            }
        }
    }
}