using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

namespace BehaviorDesigner.Runtime.Tasks.Basic.UnityRenderer
{
    [TaskCategory("Basic/Renderer")]
    [TaskDescription("Returns Success if the Renderer is visible, otherwise Failure.")]
    public class IsVisible : Conditional
    {
        public override TaskStatus OnUpdate()
        {
            if (renderer == null) {
                Debug.LogWarning("Renderer is null");
                return TaskStatus.Failure;
            }

            return renderer.isVisible ? TaskStatus.Success : TaskStatus.Failure;
        }
    }
}