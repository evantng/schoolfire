using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

namespace BehaviorDesigner.Runtime.Tasks.Basic.UnityRigidbody
{
    [TaskCategory("Basic/Rigidbody")]
    [TaskDescription("Applies a torque to the rigidbody. Returns Success.")]
    public class AddTorque : Action
    {
        [Tooltip("The amount of torque to apply")]
        public SharedVector3 torque;
        [Tooltip("The type of torque")]
        public ForceMode forceMode = ForceMode.Force;

        public override TaskStatus OnUpdate()
        {
            if (rigidbody == null) {
                Debug.LogWarning("Rigidbody is null");
                return TaskStatus.Failure;
            }

            rigidbody.AddTorque(torque.Value, forceMode);

            return TaskStatus.Success;
        }

        public override void OnReset()
        {
            if (torque != null) {
                torque.Value = Vector3.zero;
            }
            forceMode = ForceMode.Force;
        }
    }
}