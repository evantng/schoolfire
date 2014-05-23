using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

namespace BehaviorDesigner.Runtime.Tasks.Basic.UnityGameObject
{
    [TaskCategory("Basic/GameObject")]
    [TaskDescription("Returns Success if the GameObject is active in the hierarchy, otherwise Failure.")]
    public class ActiveSelf : Conditional
    {
        public override TaskStatus OnUpdate()
        {
            return gameObject.activeSelf ? TaskStatus.Success : TaskStatus.Failure;
        }
    }
}