using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

namespace BehaviorDesigner.Runtime.Tasks.Basic.UnityAnimator
{
    [TaskCategory("Basic/Animator")]
    [TaskDescription("Sets if root motion is applied. Returns Success.")]
    public class SetApplyRootMotion : Action
    {
        [Tooltip("Is root motion applied?")]
        public SharedBool rootMotion;

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

            animator.applyRootMotion = rootMotion.Value;

            return TaskStatus.Success;
        }

        public override void OnReset()
        {
            if (rootMotion != null) {
                rootMotion.Value = false;
            }
        }
    }
}