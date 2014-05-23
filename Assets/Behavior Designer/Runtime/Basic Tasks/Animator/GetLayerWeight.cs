using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

namespace BehaviorDesigner.Runtime.Tasks.Basic.UnityAnimator
{
    [TaskCategory("Basic/Animator")]
    [TaskDescription("Stores the layer's weight. Returns Success.")]
    public class GetLayerWeight : Action
    {
        [Tooltip("The index of the layer")]
        public SharedInt index;
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

            storeValue.Value = animator.GetLayerWeight(index.Value);

            return TaskStatus.Success;
        }

        public override void OnReset()
        {
            if (index != null) {
                index.Value = 0;
            }
            if (storeValue != null) {
                storeValue.Value = 0;
            }
        }
    }
}