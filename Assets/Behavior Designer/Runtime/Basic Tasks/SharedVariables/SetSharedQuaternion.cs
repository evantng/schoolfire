using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

namespace BehaviorDesigner.Runtime.Tasks.Basic.SharedVariables
{
    [TaskCategory("Basic/SharedVariable")]
    [TaskDescription("Sets the SharedQuaternion variable to the specified object. Returns Success.")]
    public class SetSharedQuaternion : Action
    {
        [Tooltip("The value to set the SharedQuaternion to")]
        public SharedQuaternion targetValue;
        [Tooltip("The SharedQuaternion to set")]
        public SharedQuaternion targetVariable;

        public override TaskStatus OnUpdate()
        {
            targetVariable.Value = targetValue.Value;

            return TaskStatus.Success;
        }

        public override void OnReset()
        {
            if (targetValue != null) {
                targetValue.Value = Quaternion.identity;
            }
            if (targetVariable != null) {
                targetVariable.Value = Quaternion.identity;
            }
        }
    }
}