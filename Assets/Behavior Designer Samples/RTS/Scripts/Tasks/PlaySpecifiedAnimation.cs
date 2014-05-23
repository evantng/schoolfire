using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;

namespace BehaviorDesigner.Samples
{
    [TaskCategory("RTS")]
    [TaskDescription("Plays the specified animation")]
    public class PlaySpecifiedAnimation : Action
    {
        [Tooltip("The name of the animation that should start playing")]
        public string animationName = "";

        public override TaskStatus OnUpdate()
        {
            // Stop the currently playing animation and play the specified animation. Return success.
            animation.Stop();
            animation.Play(animationName);
            return TaskStatus.Success;
        }
    }
}