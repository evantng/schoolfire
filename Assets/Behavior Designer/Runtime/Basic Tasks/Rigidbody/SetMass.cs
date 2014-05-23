using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

namespace BehaviorDesigner.Runtime.Tasks.Basic.UnityRigidbody
{
    [TaskCategory("Basic/Rigidbody")]
    [TaskDescription("Sets the mass of the Rigidbody. Returns Success.")]
    public class SetMass : Action
    {
        [Tooltip("The mass of the Rigidbody")]
        public SharedFloat mass;

        public override TaskStatus OnUpdate()
        {
            if (rigidbody == null) {
                Debug.LogWarning("Rigidbody is null");
                return TaskStatus.Failure;
            }

            rigidbody.mass = mass.Value;

            return TaskStatus.Success;
        }

        public override void OnReset()
        {
            if (mass != null) {
                mass.Value = 0;
            }
        }
    }
}