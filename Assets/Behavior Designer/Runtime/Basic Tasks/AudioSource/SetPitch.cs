using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

namespace BehaviorDesigner.Runtime.Tasks.Basic.UnityAudioSource
{
    [TaskCategory("Basic/AudioSource")]
    [TaskDescription("Sets the pitch value of the AudioSource. Returns Success.")]
    public class SetPitch : Action
    {
        [Tooltip("The pitch value of the AudioSource")]
        public SharedFloat pitch;

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

            audioSource.pitch = pitch.Value;

            return TaskStatus.Success;
        }

        public override void OnReset()
        {
            if (pitch != null) {
                pitch.Value = 1;
            }
        }
    }
}