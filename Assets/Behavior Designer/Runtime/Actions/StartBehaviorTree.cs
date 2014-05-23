using UnityEngine;

namespace BehaviorDesigner.Runtime.Tasks
{
    [TaskDescription("Start a new behavior tree and return success after it has been started.")]
    [HelpURL("http://www.opsive.com/assets/BehaviorDesigner/documentation.php?id=20")]
    [TaskIcon("{SkinColor}StartBehaviorTreeIcon.png")]
    public class StartBehaviorTree : Action
    {
        [Tooltip("The behavior tree that we want to start. If null use the current behavior")]
        public Behavior behavior;

        public override void OnAwake()
        {
            // If behavior is null use the behavior that this task is attached to.
            if (behavior == null) {
                behavior = Owner;
            }
        }

        public override TaskStatus OnUpdate()
        {
            // Start the behavior and return success.
            behavior.EnableBehavior();
            return TaskStatus.Success;
        }

        public override void OnReset()
        {
            // Reset the properties back to their original values.
            behavior = null;
        }
    }
}