using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

namespace BehaviorDesigner.Runtime.Tasks.Basic.UnityGameObject
{
    [TaskCategory("Basic/GameObject")]
    [TaskDescription("Stores the GameObject tag. Returns Success.")]
    public class GetTag : Action
    {
        [Tooltip("Active state of the GameObject")]
        public SharedString storeValue;

        public override TaskStatus OnUpdate()
        {
            storeValue.Value = gameObject.tag;

            return TaskStatus.Success;
        }

        public override void OnReset()
        {
            if (storeValue != null) {
                storeValue.Value = "";
            }
        }
    }
}