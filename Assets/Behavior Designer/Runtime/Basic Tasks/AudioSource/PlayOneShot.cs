using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

namespace BehaviorDesigner.Runtime.Tasks.Basic.UnityAudioSource
{
    [TaskCategory("Basic/AudioSource")]
    [TaskDescription("Plays an AudioClip, and scales the AudioSource volume by volumeScale. Returns Success.")]
    public class PlayOneShot : Action
    {
        [Tooltip("The clip being played")]
        public SharedObject clip;
        [Tooltip("The scale of the volume (0-1)")]
        float volumeScale = 1;

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

            audioSource.PlayOneShot((AudioClip)clip.Value, volumeScale);

            return TaskStatus.Success;
        }

        public override void OnReset()
        {
            if (clip != null) {
                clip.Value = null;
            }
            volumeScale = 1;
        }
    }
}