using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

namespace BehaviorDesigner.Runtime.Tasks.Basic.UnityAnimation
{
    [TaskCategory("Basic/Animation")]
    [TaskDescription("Sets the wrap mode to the specified value. Returns Success.")]
    public class SetWrapMode : Action
    {
        [Tooltip("How should time beyond the playback range of the clip be treated?")]
        public WrapMode wrapMode = WrapMode.Default;

        public override TaskStatus OnUpdate()
        {
            if (animation == null) {
                Debug.LogWarning("Animation is null");
                return TaskStatus.Failure;
            }

            animation.wrapMode = wrapMode;

            return TaskStatus.Success;
        }

        public override void OnReset()
        {
            wrapMode = WrapMode.Default;
        }
    }
}