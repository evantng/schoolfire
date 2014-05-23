using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

namespace BehaviorDesigner.Samples
{
    [TaskCategory("MiniGauntlet")]
    [TaskDescription("Enables or disables the Mecanim animator")]
    public class EnableAnimator : Action
    {
        [Tooltip("Enable or disable the animator")]
        public SharedBool enable;

        public override TaskStatus OnUpdate()
        {
            // enable or disable and return
            gameObject.GetComponent<Animator>().enabled = (enable != null ? enable.Value : false);
            return TaskStatus.Success;
        }

        public override void OnReset()
        {
            if (enable != null) {
                enable.Value = false;
            }
        }
    }
}