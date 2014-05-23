using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

namespace BehaviorDesigner.Samples
{
    [TaskCategory("MiniGauntlet")]
    [TaskDescription("Sets the float parameter on a Mecanim controller. Returns success immediately after.")]
    public class SetFloatParameter : Action
    {
        [Tooltip("The float parameter")]
        public string floatName;
        [Tooltip("The value of that float parameter")]
        public SharedFloat floatValue;

        private int floatID;
        private Animator animator = null;

        public override void OnAwake()
        {
            // cache the values early on to prevent multiple lookups
            animator = gameObject.GetComponent<Animator>();
            floatID = Animator.StringToHash(floatName);
        }

        public override TaskStatus OnUpdate()
        {
            // set the float and return
            animator.SetFloat(floatID, floatValue.Value);
            return TaskStatus.Success;
        }

        public override void OnReset()
        {
            floatName = "";
        }
    }
}