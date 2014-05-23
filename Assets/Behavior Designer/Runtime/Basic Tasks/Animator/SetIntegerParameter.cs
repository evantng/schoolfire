using UnityEngine;
using System.Collections;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

namespace BehaviorDesigner.Runtime.Tasks.Basic.UnityAnimator
{
    [TaskCategory("Basic/Animator")]
    [TaskDescription("Sets the float parameter on an animator. Returns Success.")]
    public class SetIntegerParameter : Action
    {
        [Tooltip("The name of the parameter")]
        public SharedString paramaterName;
        [Tooltip("The value of the int parameter")]
        public SharedInt intValue;
        [Tooltip("Should the value be reverted back to its original value after it has been set?")]
        public bool setOnce;

        private int hashID;
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

            hashID = UnityEngine.Animator.StringToHash(paramaterName.Value);

            int prevValue = animator.GetInteger(hashID);
            animator.SetInteger(hashID, intValue.Value);
            if (setOnce) {
                StartCoroutine(ResetValue(prevValue));
            }

            return TaskStatus.Success;
        }

        public IEnumerator ResetValue(int origVale)
        {
            yield return null;
            animator.SetInteger(hashID, origVale);
        }

        public override void OnReset()
        {
            if (paramaterName.Value != null) {
                paramaterName.Value = "";
            }
            if (intValue != null) {
                intValue.Value = 0;
            }
        }
    }
}