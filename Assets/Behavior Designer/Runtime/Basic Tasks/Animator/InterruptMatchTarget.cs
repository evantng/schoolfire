using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

namespace BehaviorDesigner.Runtime.Tasks.Basic.UnityAnimator
{
    [TaskCategory("Basic/Animator")]
    [TaskDescription("Interrupts the automatic target matching. Returns Success.")]
    public class InterruptMatchTarget : Action
    {
        [Tooltip("CompleteMatch will make the gameobject match the target completely at the next frame")]
        public bool completeMatch = true;

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

            animator.InterruptMatchTarget(completeMatch);

            return TaskStatus.Success;
        }

        public override void OnReset()
        {
            completeMatch = true;
        }
    }
}