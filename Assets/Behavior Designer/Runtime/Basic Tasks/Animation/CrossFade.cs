using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using UnityAnimation = UnityEngine.Animation;

namespace BehaviorDesigner.Runtime.Tasks.Basic.UnityAnimation
{
    [TaskCategory("Basic/Animation")]
    [TaskDescription("Fades the animation over a period of time and fades other animations out. Returns Success.")]
    public class CrossFade : Action
    {
        [Tooltip("The name of the animation")]
        public SharedString animationName;
        [Tooltip("The amount of time it takes to blend")]
        public float fadeLength = 0.3f;
        [Tooltip("The play mode of the animation")]
        public PlayMode playMode = PlayMode.StopSameLayer;

        public override TaskStatus OnUpdate()
        {
            if (animation == null) {
                Debug.LogWarning("Animation is null");
                return TaskStatus.Failure;
            }

            animation.CrossFade(animationName.Value, fadeLength, playMode);

            return TaskStatus.Success;
        }

        public override void OnReset()
        {
            if (animationName != null) {
                animationName.Value = "";
            }
            fadeLength = 0.3f;
            playMode = PlayMode.StopSameLayer;
        }
    }
}