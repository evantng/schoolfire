using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

namespace BehaviorDesigner.Runtime.Tasks.Basic.UnityAudioSource
{
    [TaskCategory("Basic/AudioSource")]
    [TaskDescription("Sets the mute value of the AudioSource. Returns Success.")]
    public class SetMute : Action
    {
        [Tooltip("The mute value of the AudioSource")]
        public SharedBool mute;

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

            audioSource.mute = mute.Value;

            return TaskStatus.Success;
        }

        public override void OnReset()
        {
            if (mute != null) {
                mute.Value = false;
            }
        }
    }
}