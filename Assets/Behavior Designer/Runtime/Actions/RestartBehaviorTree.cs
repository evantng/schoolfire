using UnityEngine;

namespace BehaviorDesigner.Runtime.Tasks
{
    [TaskDescription("Restarts a behavior tree, returns success after it has been restarted.")]
    [HelpURL("http://www.opsive.com/assets/BehaviorDesigner/documentation.php?id=66")]
    [TaskIcon("{SkinColor}RestartBehaviorTreeIcon.png")]
    public class RestartBehaviorTree : Action
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
            // Stop the behavior tree
            behavior.DisableBehavior();
            // Start the behavior tree back up
            behavior.EnableBehavior();
            // Return success
            return TaskStatus.Success;
        }

        public override void OnReset()
        {
            // Reset the properties back to their original values.
            behavior = null;
        }
    }
}