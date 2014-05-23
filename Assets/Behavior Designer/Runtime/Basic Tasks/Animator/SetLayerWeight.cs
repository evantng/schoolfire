using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

namespace BehaviorDesigner.Runtime.Tasks.Basic.UnityAnimator
{
    [TaskCategory("Basic/Animator")]
    [TaskDescription("Sets the layer's current weight. Returns Success.")]
    public class SetLayerWeight : Action
    {
        [Tooltip("The layer's index")]
        public SharedInt index;
        [Tooltip("The weight of the layer")]
        public SharedFloat weight;

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

            animator.SetLayerWeight(index.Value, weight.Value);

            return TaskStatus.Success;
        }

        public override void OnReset()
        {
            if (index != null) {
                index.Value = 0;
            }
            if (weight != null) {
                weight.Value = 0;
            }
        }
    }
}