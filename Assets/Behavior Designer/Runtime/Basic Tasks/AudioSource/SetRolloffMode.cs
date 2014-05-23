using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

namespace BehaviorDesigner.Runtime.Tasks.Basic.UnityAudioSource
{
    [TaskCategory("Basic/AudioSource")]
    [TaskDescription("Sets the rolloff mode of the AudioSource. Returns Success.")]
    public class SetRolloffMode : Action
    {
        [Tooltip("The rolloff mode of the AudioSource")]
        public AudioRolloffMode rolloffMode;

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

            audioSource.rolloffMode = rolloffMode;

            return TaskStatus.Success;
        }

        public override void OnReset()
        {
            rolloffMode = AudioRolloffMode.Logarithmic;
        }
    }
}