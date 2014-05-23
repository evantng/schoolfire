using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

namespace BehaviorDesigner.Runtime.Tasks.Basic.UnityGameObject
{
    [TaskCategory("Basic/GameObject")]
    [TaskDescription("Activates/Deactivates the GameObject. Returns Success.")]
    public class SetActive : Action
    {
        [Tooltip("Active state of the GameObject")]
        public SharedBool active;

        public override TaskStatus OnUpdate()
        {
            gameObject.SetActive(active.Value);

            return TaskStatus.Success;
        }

        public override void OnReset()
        {
            if (active != null) {
                active.Value = false;
            }
        }
    }
}