using UnityEngine;
using System.Collections;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

namespace BehaviorDesigner.Samples
{
    [TaskCategory("MiniGauntlet")]
    [TaskDescription("Sets the bool parameter on the Mecanim controller. Returns success immediately after.")]
    public class SetBoolParameter : Action
    {
        [Tooltip("Name of the bool parameter")]
        public string boolName;
        [Tooltip("The value to set the bool parameter to")]
        public SharedBool boolValue;
        [Tooltip("Should the bool value be reverted back to its original value after it has been set?")]
        public bool setOnce;

        private int boolID;
        private Animator animator = null;

        public override void OnAwake()
        {
            animator = gameObject.GetComponent<Animator>();
            boolID = Animator.StringToHash(boolName);
        }

        public override TaskStatus OnUpdate()
        {
            bool prevValue = animator.GetBool(boolName);
            animator.SetBool(boolID, boolValue.Value);
            if (setOnce) {
                StartCoroutine(resetBoolValue(prevValue));
            }
            return TaskStatus.Success;
        }

        public IEnumerator resetBoolValue(bool origVale)
        {
            yield return null;
            animator.SetBool(boolID, origVale);
        }
    }
}