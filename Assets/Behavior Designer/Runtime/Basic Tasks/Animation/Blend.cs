using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

namespace BehaviorDesigner.Runtime.Tasks.Basic.UnityAnimation
{
    [TaskCategory("Basic/Animation")]
    [TaskDescription("Blends the animation. Returns Success.")]
    public class Blend : Action
    {
        [Tooltip("The name of the animation")]
        public SharedString animationName;
        [Tooltip("The weight the animation should blend to")]
        public float targetWeight = 1;
        [Tooltip("The amount of time it takes to blend")]
        public float fadeLength = 0.3f;

        public override TaskStatus OnUpdate()
        {
            if (animation == null) {
                Debug.LogWarning("Animation is null");
                return TaskStatus.Failure;
            }

            animation.Blend(animationName.Value, targetWeight, fadeLength);

            return TaskStatus.Success;
        }

        public override void OnReset()
        {
            if (animationName != null) {
                animationName.Value = "";
            }
            targetWeight = 1;
            fadeLength = 0.3f;
        }
    }
}