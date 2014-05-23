using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

namespace BehaviorDesigner.Runtime.Tasks.Basic.UnityRigidbody
{
    [TaskCategory("Basic/Rigidbody")]
    [TaskDescription("Applies a force at the specified position to the rigidbody. Returns Success.")]
    public class AddForceAtPosition : Action
    {
        [Tooltip("The amount of force to apply")]
        public SharedVector3 force;
        [Tooltip("The position of the force")]
        public SharedVector3 position;
        [Tooltip("The type of force")]
        public ForceMode forceMode = ForceMode.Force;

        public override TaskStatus OnUpdate()
        {
            if (rigidbody == null) {
                Debug.LogWarning("Rigidbody is null");
                return TaskStatus.Failure;
            }

            rigidbody.AddForceAtPosition(force.Value, position.Value, forceMode);

            return TaskStatus.Success;
        }

        public override void OnReset()
        {
            if (force != null) {
                force.Value = Vector3.zero;
            }
            if (position != null) {
                position.Value = Vector3.zero;
            }
            forceMode = ForceMode.Force;
        }
    }
}