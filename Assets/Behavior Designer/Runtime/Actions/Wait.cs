using UnityEngine;

namespace BehaviorDesigner.Runtime.Tasks
{
    [TaskDescription("Wait a specified amount of time. The task will return running until the task is done waiting. It will return success after the wait time has elapsed.")]
    [HelpURL("http://www.opsive.com/assets/BehaviorDesigner/documentation.php?id=22")]
    [TaskIcon("{SkinColor}WaitIcon.png")]
    public class Wait : Action
    {
        [Tooltip("The amount of time to wait")]
        public float waitTime = 1;

        // The time that the task started to wait.
        private float startTime;
        // Remember the time that the task is paused so the time paused doesn't contribute to the wait time.
        private float pauseTime;

        public override void OnStart()
        {
            // Remember the start time.
            startTime = Time.time;
        }

        public override TaskStatus OnUpdate()
        {
            // The task is done waiting if the time waitTime has elapsed since the task was started.
            if (startTime + waitTime < Time.time) {
                return TaskStatus.Success;
            }
            // Otherwise we are still waiting.
            return TaskStatus.Running;
        }

        public override void OnPause(bool paused)
        {
            if (paused) {
                // Remember the time that the behavior was paused/
                pauseTime = Time.time;
            } else {
                // Add the difference between Time.time and pauseTime to figure out a new start time.
                startTime += (Time.time - pauseTime);
            }
        }

        public override void OnReset()
        {
            // Reset the public properties back to their original values
            waitTime = 1;
        }
    }
}