#if !(UNITY_4_0 || UNITY_4_0_1 || UNITY_4_1 || UNITY_4_2)
using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

namespace BehaviorDesigner.Runtime.Tasks.Basic.UnityAnimator
{
    [TaskCategory("Basic/Animator")]
    [TaskDescription("Plays an animator state. Returns Success.")]
    public class Play : Action
    {
        [Tooltip("The name of the state")]
        public SharedString stateName;
        [Tooltip("The layer where the state is")]
        public int layer = -1;
        [Tooltip("The normalized time at which the state will play")]
        public float normalizedTime = float.NegativeInfinity;

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

            animator.Play(stateName.Value, layer, normalizedTime);

            return TaskStatus.Success;
        }

        public override void OnReset()
        {
            if (stateName != null) {
                stateName.Value = "";
            }
            layer = -1;
            normalizedTime = float.NegativeInfinity;
        }
    }
}
#endif