using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

namespace BehaviorDesigner.Runtime.Tasks.Basic.UnityAnimation
{
    [TaskCategory("Basic/Animation")]
    [TaskDescription("Returns Success if the animation is currently playing.")]
    public class IsPlaying : Conditional
    {
        [Tooltip("The name of the animation")]
        public SharedString animationName;

        public override TaskStatus OnUpdate()
        {
            if (animation == null) {
                Debug.LogWarning("Animation is null");
                return TaskStatus.Failure;
            }
            
            if (string.IsNullOrEmpty(animationName.Value)) {
                return animation.isPlaying ? TaskStatus.Success : TaskStatus.Failure;
            } else {
                return animation.IsPlaying(animationName.Value) ? TaskStatus.Success : TaskStatus.Failure;
            }
        }

        public override void OnReset()
        {
            if (animationName != null) {
                animationName.Value = "";
            }
        }
    }
}