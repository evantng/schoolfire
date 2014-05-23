using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

namespace BehaviorDesigner.Runtime.Tasks.Basic.UnityRigidbody
{
    [TaskCategory("Basic/Rigidbody")]
    [TaskDescription("Applies a force to the rigidbody relative to its coordinate system. Returns Success.")]
    public class AddRelativeForce : Action
    {
        [Tooltip("The amount of force to apply")]
        public SharedVector3 force;
        [Tooltip("The type of force")]
        public ForceMode forceMode = ForceMode.Force;

        public override TaskStatus OnUpdate()
        {
            if (rigidbody == null) {
                Debug.LogWarning("Rigidbody is null");
                return TaskStatus.Failure;
            }

            rigidbody.AddRelativeForce(force.Value, forceMode);

            return TaskStatus.Success;
        }

        public override void OnReset()
        {
            if (force != null) {
                force.Value = Vector3.zero;
            }
            forceMode = ForceMode.Force;
        }
    }
}