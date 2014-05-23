using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

namespace BehaviorDesigner.Runtime.Tasks.Basic.UnityAnimation
{
    [TaskCategory("Basic/Animation")]
    [TaskDescription("Cross fades an animation after previous animations has finished playing. Returns Success.")]
    public class CrossFadeQueued : Action
    {
        [Tooltip("The name of the animation")]
        public SharedString animationName;
        [Tooltip("The amount of time it takes to blend")]
        public float fadeLength = 0.3f;
        [Tooltip("Specifies when the animation should start playing")]
        public QueueMode queue = QueueMode.CompleteOthers;
        [Tooltip("The play mode of the animation")]
        public PlayMode playMode = PlayMode.StopSameLayer;

        public override TaskStatus OnUpdate()
        {
            if (animation == null) {
                Debug.LogWarning("Animation is null");
                return TaskStatus.Failure;
            }

            animation.CrossFadeQueued(animationName.Value, fadeLength, queue, playMode);

            return TaskStatus.Success;
        }

        public override void OnReset()
        {
            if (animationName != null) {
                animationName.Value = "";
            }
            fadeLength = 0.3f;
            queue = QueueMode.CompleteOthers;
            playMode = PlayMode.StopSameLayer;
        }
    }
}