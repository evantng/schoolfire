using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

namespace BehaviorDesigner.Runtime.Tasks.Basic.UnityAudioSource
{
    [TaskCategory("Basic/AudioSource")]
    [TaskDescription("Sets the volume value of the AudioSource. Returns Success.")]
    public class SetVolume : Action
    {
        [Tooltip("The volume value of the AudioSource")]
        public SharedFloat volume;

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

            audioSource.volume = volume.Value;

            return TaskStatus.Success;
        }

        public override void OnReset()
        {
            if (volume != null) {
                volume.Value = 1;
            }
        }
    }
}