using UnityEngine;

namespace BehaviorDesigner.Runtime.Tasks
{
    // Wrapper class for the External Behavior task. The external behavior tree task allows you to run another behavior tree within the current behavior tree. 
    // One use for this task is if you have an unit that plays a series of tasks to attack. You may want the unit to attack at different points within
    // the behavior tree, and you want that attack to always be the same. Instead of copying and pasting the same tasks over and over you can just use
    // an external behavior and then the tasks are always guaranteed to be the same. This example is demonstrated in the RTS sample project located at
    // http://www.opsive.com/assets/BehaviorDesigner/samples.php.
    [TaskDescription("External Behavior Tree allows you to run another behavior tree within the current behavior tree.")]
    [HelpURL("http://www.opsive.com/assets/BehaviorDesigner/documentation.php?id=15")]
    [TaskIcon("ExternalBehaviorTreeIcon.png")]
    [System.Obsolete("External Behavior Tree Task is deprecated. Use Behavior Tree Reference Task instead.")]
    public class ExternalBehaviorTree : ExternalBehavior
    {
        // intentionally left blank - subclass of ExternalBehavior
    }
}