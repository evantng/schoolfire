using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

namespace BehaviorDesigner.Runtime.Tasks.Basic.SharedVariables
{
    [TaskCategory("Basic/SharedVariable")]
    [TaskDescription("Sets the SharedVector4 variable to the specified object. Returns Success.")]
    public class SetSharedVector4 : Action
    {
        [Tooltip("The value to set the SharedVector4 to")]
        public SharedVector4 targetValue;
        [Tooltip("The SharedVector4 to set")]
        public SharedVector4 targetVariable;

        public override TaskStatus OnUpdate()
        {
            targetVariable.Value = targetValue.Value;

            return TaskStatus.Success;
        }

        public override void OnReset()
        {
            if (targetValue != null) {
                targetValue.Value = Vector4.zero;
            }
            if (targetVariable != null) {
                targetVariable.Value = Vector4.zero;
            }
        }
    }
}