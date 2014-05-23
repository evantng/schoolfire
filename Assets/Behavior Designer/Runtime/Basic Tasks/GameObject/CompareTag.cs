using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

namespace BehaviorDesigner.Runtime.Tasks.Basic.UnityGameObject
{
    [TaskCategory("Basic/GameObject")]
    [TaskDescription("Returns Success if tags match, otherwise Failure.")]
    public class CompareTag : Conditional
    {
        [Tooltip("The tag to compare against")]
        public SharedString tag;

        public override TaskStatus OnUpdate()
        {
            return gameObject.CompareTag(tag.Value) ? TaskStatus.Success : TaskStatus.Failure;
        }

        public override void OnReset()
        {
            if (tag != null) {
                tag.Value = "";
            }
        }
    }
}