using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

namespace BehaviorDesigner.Runtime.Tasks.Basic.UnityAnimator
{
    [TaskCategory("Basic/Animator")]
    [TaskDescription("Sets the look at position. Returns Success.")]
    public class SetLookAtPosition : Action
    {
        [Tooltip("The position to lookAt")]
        public SharedVector3 position;

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

            animator.SetLookAtPosition(position.Value);

            return TaskStatus.Success;
        }

        public override void OnReset()
        {
            if (position != null) {
                position.Value = Vector3.zero;
            }
        }
    }
}