using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

namespace BehaviorDesigner.Runtime.Tasks.Basic.UnityRigidbody
{
    [TaskCategory("Basic/Rigidbody")]
    [TaskDescription("Sets the freeze rotation value of the Rigidbody. Returns Success.")]
    public class SetFreezeRotation : Action
    {
        [Tooltip("The freeze rotation value of the Rigidbody")]
        public SharedBool freezeRotation;

        public override TaskStatus OnUpdate()
        {
            if (rigidbody == null) {
                Debug.LogWarning("Rigidbody is null");
                return TaskStatus.Failure;
            }

            rigidbody.freezeRotation = freezeRotation.Value;

            return TaskStatus.Success;
        }

        public override void OnReset()
        {
            if (freezeRotation != null) {
                freezeRotation.Value = false;
            }
        }
    }
}