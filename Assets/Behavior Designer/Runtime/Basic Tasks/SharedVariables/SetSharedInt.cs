using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

namespace BehaviorDesigner.Runtime.Tasks.Basic.SharedVariables
{
    [TaskCategory("Basic/SharedVariable")]
    [TaskDescription("Sets the SharedInt variable to the specified object. Returns Success.")]
    public class SetSharedInt : Action
    {
        [Tooltip("The value to set the SharedInt to")]
        public SharedInt targetValue;
        [Tooltip("The SharedInt to set")]
        public SharedInt targetVariable;

        public override TaskStatus OnUpdate()
        {
            targetVariable.Value = targetValue.Value;

            return TaskStatus.Success;
        }

        public override void OnReset()
        {
            if (targetValue != null) {
                targetValue.Value = 0;
            }
            if (targetVariable != null) {
                targetVariable.Value = 0;
            }
        }
    }
}