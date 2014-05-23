using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

namespace BehaviorDesigner.Runtime.Tasks.Basic.SharedVariables
{
    [TaskCategory("Basic/SharedVariable")]
    [TaskDescription("Sets the SharedColor variable to the specified object. Returns Success.")]
    public class SetSharedColor : Action
    {
        [Tooltip("The value to set the SharedColor to")]
        public SharedColor targetValue;
        [Tooltip("The SharedColor to set")]
        public SharedColor targetVariable;

        public override TaskStatus OnUpdate()
        {
            targetVariable.Value = targetValue.Value;

            return TaskStatus.Success;
        }

        public override void OnReset()
        {
            if (targetValue != null) {
                targetValue.Value = Color.black;
            }
            if (targetVariable != null) {
                targetVariable.Value = Color.black;
            }
        }
    }
}