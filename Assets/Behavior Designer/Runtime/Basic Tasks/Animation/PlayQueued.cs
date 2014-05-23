using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

namespace BehaviorDesigner.Runtime.Tasks.Basic.UnityAnimation
{
    [TaskCategory("Basic/Animation")]
    [TaskDescription("Plays an animation after previous animations has finished playing. Returns Success.")]
    public class PlayQueued : Action
    {
        [Tooltip("The name of the animation")]
        public SharedString animationName;
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

            animation.PlayQueued(animationName.Value, queue, playMode);

            return TaskStatus.Success;
        }

        public override void OnReset()
        {
            if (animationName != null) {
                animationName.Value = "";
            }
            queue = QueueMode.CompleteOthers;
            playMode = PlayMode.StopSameLayer;
        }
    }
}