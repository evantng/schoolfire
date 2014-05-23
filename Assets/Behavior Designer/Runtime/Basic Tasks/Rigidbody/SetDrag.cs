using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

namespace BehaviorDesigner.Runtime.Tasks.Basic.UnityRigidbody
{
    [TaskCategory("Basic/Rigidbody")]
    [TaskDescription("Sets the drag of the Rigidbody. Returns Success.")]
    public class SetDrag : Action
    {
        [Tooltip("The drag of the Rigidbody")]
        public SharedFloat drag;

        public override TaskStatus OnUpdate()
        {
            if (rigidbody == null) {
                Debug.LogWarning("Rigidbody is null");
                return TaskStatus.Failure;
            }

            rigidbody.drag = drag.Value;

            return TaskStatus.Success;
        }

        public override void OnReset()
        {
            if (drag != null) {
                drag.Value = 0;
            }
        }
    }
}