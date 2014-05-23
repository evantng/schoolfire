using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

namespace BehaviorDesigner.Runtime.Tasks.Basic.UnityAnimator
{
    [TaskCategory("Basic/Animator")]
    [TaskDescription("Returns success if the specified parameter is controlled by an additional curve on an animation.")]
    public class IsParameterControlledByCurve : Conditional
    {
        [Tooltip("The name of the parameter")]
        public SharedString paramaterName;

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

            return animator.IsParameterControlledByCurve(paramaterName.Value) ? TaskStatus.Success : TaskStatus.Failure;
        }

        public override void OnReset()
        {
            if (paramaterName != null) {
                paramaterName.Value = "";
            }
        }
    }
}