using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

namespace BehaviorDesigner.Runtime.Tasks.Basic.UnityAnimator
{
    [TaskCategory("Basic/Animator")]
    [TaskDescription("Sets the playback speed of the Animator. 1 is normal playback speed. Returns Success.")]
    public class SetSpeed : Action
    {
        [Tooltip("The playback speed of the Animator")]
        public SharedFloat speed;

        private Animator animator;

        public override void OnAwake()
        {
            animator = gameObject.GetComponent<Animator>();
        }

        public override TaskStatus OnUpdate()
        {
            if (animator == null) {
                Debug.LogWarning("Animator is null");
                return TaskStatus.Failure;
            }

            animator.speed = speed.Value;

            return TaskStatus.Success;
        }

        public override void OnReset()
        {
            if (speed != null) {
                speed.Value = 0;
            }
        }
    }
}