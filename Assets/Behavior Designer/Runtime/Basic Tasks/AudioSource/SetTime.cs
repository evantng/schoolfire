using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

namespace BehaviorDesigner.Runtime.Tasks.Basic.UnityAudioSource
{
    [TaskCategory("Basic/AudioSource")]
    [TaskDescription("Sets the time value of the AudioSource. Returns Success.")]
    public class SeTime : Action
    {
        [Tooltip("The time value of the AudioSource")]
        public SharedFloat time;

        private AudioSource audioSource;

        public override void OnAwake()
        {
            audioSource = gameObject.GetComponent<AudioSource>();
        }

        public override TaskStatus OnUpdate()
        {
            if (audioSource == null) {
                Debug.LogWarning("AudioSource is null");
                return TaskStatus.Failure;
            }

            audioSource.time = time.Value;

            return TaskStatus.Success;
        }

        public override void OnReset()
        {
            if (time != null) {
                time.Value = 1;
            }
        }
    }
}