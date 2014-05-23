using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

namespace BehaviorDesigner.Runtime.Tasks.Basic.UnityAudioSource
{
    [TaskCategory("Basic/AudioSource")]
    [TaskDescription("Sets the ignore listener volume value of the AudioSource. Returns Success.")]
    public class SetIgnoreListenerVolume : Action
    {
        [Tooltip("The ignore listener volume value of the AudioSource")]
        public SharedBool ignoreListenerVolume;

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

            audioSource.ignoreListenerVolume = ignoreListenerVolume.Value;

            return TaskStatus.Success;
        }

        public override void OnReset()
        {
            if (ignoreListenerVolume != null) {
                ignoreListenerVolume.Value = false;
            }
        }
    }
}