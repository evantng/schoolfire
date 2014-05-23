using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

namespace BehaviorDesigner.Runtime.Tasks.Basic.SharedVariables
{
    [TaskCategory("Basic/SharedVariable")]
    [TaskDescription("Sets the SharedGameObject variable to the specified object. Returns Success.")]
    public class SetSharedGameObject : Action
    {
        [Tooltip("The value to set the SharedGameObject to. If null the variable will be set to the current GameObject")]
        public SharedGameObject targetValue;
        [Tooltip("The SharedGameObject to set")]
        public SharedGameObject targetVariable;

        public override TaskStatus OnUpdate()
        {
            targetVariable.Value = (targetValue.Value != null ? targetValue.Value : gameObject);

            return TaskStatus.Success;
        }

        public override void OnReset()
        {
            if (targetValue != null) {
                targetValue.Value = null;
            }
            if (targetVariable != null) {
                targetVariable.Value = null;
            }
        }
    }
}