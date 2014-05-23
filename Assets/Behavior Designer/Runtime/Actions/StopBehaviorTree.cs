using UnityEngine;

namespace BehaviorDesigner.Runtime.Tasks
{
    [TaskDescription("Pause or disable a behavior tree and return success after it has been stopped.")]
    [HelpURL("http://www.opsive.com/assets/BehaviorDesigner/documentation.php?id=21")]
    [TaskIcon("{SkinColor}StopBehaviorTreeIcon.png")]
    public class StopBehaviorTree : Action
    {
        [Tooltip("The behavior tree that we want to stop. If null use the current behavior")]
        public Behavior behavior;
        [Tooltip("Should the behavior be paused or completely disabled")]
        public bool pauseBehavior = false;

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
            behavior.DisableBehavior(pauseBehavior);
            return TaskStatus.Success;
        }

        public override void OnReset()
        {
            // Reset the properties back to their original values
            behavior = null;
            pauseBehavior = false;
        }
    }
}