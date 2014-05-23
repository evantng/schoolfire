using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

namespace BehaviorDesigner.Runtime.Tasks.Basic.UnityAnimation
{
    [TaskCategory("Basic/Animation")]
    [TaskDescription("Stops an animation. Stops all animations if animationName is blank. Returns Success.")]
    public class Stop : Action
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
                animation.Stop();
            } else {
                animation.Stop(animationName.Value);
            }

            return TaskStatus.Success;
        }

        public override void OnReset()
        {
            if (animationName != null) {
                animationName.Value = "";
            }
        }
    }
}