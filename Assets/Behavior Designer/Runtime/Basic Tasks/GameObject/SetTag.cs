using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

namespace BehaviorDesigner.Runtime.Tasks.Basic.UnityGameObject
{
    [TaskCategory("Basic/GameObject")]
    [TaskDescription("Sets the GameObject tag. Returns Success.")]
    public class SetTag : Action
    {
        [Tooltip("The GameObject tag")]
        public SharedString tag;

        public override TaskStatus OnUpdate()
        {
            gameObject.tag = tag.Value;

            return TaskStatus.Success;
        }

        public override void OnReset()
        {
            if (tag != null) {
                tag.Value = "";
            }
        }
    }
}