using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

namespace BehaviorDesigner.Samples.DialogueSystem
{
    [TaskDescription("Assigns the foundGameObject variable to the current GameObject")]
    [TaskCategory("Dialogue System")]
    public class AssignGameObject : Action
    {
        [Tooltip("The variable to assign the GameObject to")]
        public SharedGameObject foundGameObject;

        public override TaskStatus OnUpdate()
        {
            foundGameObject.Value = gameObject;
            return TaskStatus.Success;
        }

        // Reset the public variables
        public override void OnReset()
        {
            foundGameObject.Value = null;
        }
    }
}