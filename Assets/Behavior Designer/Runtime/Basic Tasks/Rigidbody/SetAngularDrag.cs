using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

namespace BehaviorDesigner.Runtime.Tasks.Basic.UnityRigidbody
{
    [TaskCategory("Basic/Rigidbody")]
    [TaskDescription("Sets the angular drag of the Rigidbody. Returns Success.")]
    public class SetAngularDrag : Action
    {
        [Tooltip("The angular drag of the Rigidbody")]
        public SharedFloat angularDrag;

        public override TaskStatus OnUpdate()
        {
            if (rigidbody == null) {
                Debug.LogWarning("Rigidbody is null");
                return TaskStatus.Failure;
            }

            rigidbody.angularDrag = angularDrag.Value;

            return TaskStatus.Success;
        }

        public override void OnReset()
        {
            if (angularDrag != null) {
                angularDrag.Value = 0;
            }
        }
    }
}