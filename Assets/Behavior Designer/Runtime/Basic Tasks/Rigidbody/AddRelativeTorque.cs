using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

namespace BehaviorDesigner.Runtime.Tasks.Basic.UnityRigidbody
{
    [TaskCategory("Basic/Rigidbody")]
    [TaskDescription("Applies a torque to the rigidbody relative to its coordinate system. Returns Success.")]
    public class AddRelativeTorque : Action
    {
        [Tooltip("The amount of torque to apply")]
        public SharedVector3 torque;
        [Tooltip("The type of torque")]
        public ForceMode forceMode = ForceMode.Force;

        public override TaskStatus OnUpdate()
        {
            rigidbody.AddRelativeTorque(torque.Value, forceMode);

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