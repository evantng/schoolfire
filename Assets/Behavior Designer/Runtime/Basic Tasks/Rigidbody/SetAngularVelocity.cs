using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

namespace BehaviorDesigner.Runtime.Tasks.Basic.UnityRigidbody
{
    [TaskCategory("Basic/Rigidbody")]
    [TaskDescription("Sets the angular velocity of the Rigidbody. Returns Success.")]
    public class SetAngularVelocity : Action
    {
        [Tooltip("The angular velocity of the Rigidbody")]
        public SharedVector3 angularVelocity;

        public override TaskStatus OnUpdate()
        {
            if (rigidbody == null) {
                Debug.LogWarning("Rigidbody is null");
                return TaskStatus.Failure;
            }

            rigidbody.angularVelocity = angularVelocity.Value;

            return TaskStatus.Success;
        }

        public override void OnReset()
        {
            if (angularVelocity != null) {
                angularVelocity.Value = Vector3.zero;
            }
        }
    }
}