using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

namespace BehaviorDesigner.Runtime.Tasks.Basic.UnityAnimator
{
    [TaskCategory("Basic/Animator")]
    [TaskDescription("Stores the float parameter on an animator. Returns Success.")]
    public class GetFloatParameter : Action
    {
        [Tooltip("The name of the parameter")]
        public SharedString paramaterName;
        [Tooltip("The value of the float parameter")]
        public SharedFloat storeValue;

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

            storeValue.Value = animator.GetFloat(paramaterName.Value);

            return TaskStatus.Success;
        }

        public override void OnReset()
        {
            if (paramaterName.Value != null) {
                paramaterName.Value = "";
            }
            if (storeValue != null) {
                storeValue.Value = 0;
            }
        }
    }
}