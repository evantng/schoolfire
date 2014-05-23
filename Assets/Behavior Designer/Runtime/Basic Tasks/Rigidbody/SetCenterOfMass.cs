using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

namespace BehaviorDesigner.Runtime.Tasks.Basic.UnityRigidbody
{
    [TaskCategory("Basic/Rigidbody")]
    [TaskDescription("Sets the center of mass of the Rigidbody. Returns Success.")]
    public class SetCenterOfMass : Action
    {
        [Tooltip("The center of mass of the Rigidbody")]
        public SharedVector3 centerOfMass;

        public override TaskStatus OnUpdate()
        {
            if (rigidbody == null) {
                Debug.LogWarning("Rigidbody is null");
                return TaskStatus.Failure;
            }

            rigidbody.centerOfMass = centerOfMass.Value;

            return TaskStatus.Success;
        }

        public override void OnReset()
        {
            if (centerOfMass != null) {
                centerOfMass.Value = Vector3.zero;
            }
        }
    }
}