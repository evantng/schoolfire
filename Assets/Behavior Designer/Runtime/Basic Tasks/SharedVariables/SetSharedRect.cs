using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

namespace BehaviorDesigner.Runtime.Tasks.Basic.SharedVariables
{
    [TaskCategory("Basic/SharedVariable")]
    [TaskDescription("Sets the SharedRect variable to the specified object. Returns Success.")]
    public class SetSharedRect : Action
    {
        [Tooltip("The value to set the SharedRect to")]
        public SharedRect targetValue;
        [Tooltip("The SharedRect to set")]
        public SharedRect targetVariable;

        public override TaskStatus OnUpdate()
        {
            targetVariable.Value = targetValue.Value;

            return TaskStatus.Success;
        }

        public override void OnReset()
        {
            if (targetValue != null) {
                targetValue.Value = new Rect();
            }
            if (targetVariable != null) {
                targetVariable.Value = new Rect();
            }
        }
    }
}