using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;

namespace BehaviorDesigner.Runtime.Samples
{
    [TaskCategory("MiniGauntlet")]
    [TaskDescription("Plays the sound on the AudioSource attached to the GameObject")]
    public class PlaySound : Action
    {
        public override TaskStatus OnUpdate()
        {
            gameObject.GetComponent<AudioSource>().Play();
            return TaskStatus.Success;
        }
    }
}