using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

namespace BehaviorDesigner.Runtime.Tasks.Basic.UnityAudioSource
{
    [TaskCategory("Basic/AudioSource")]
    [TaskDescription("Sets the pan value of the AudioSource. Returns Success.")]
    public class SetPan : Action
    {
        [Tooltip("The pan value of the AudioSource")]
        public SharedFloat pan;

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

            audioSource.pan = pan.Value;

            return TaskStatus.Success;
        }

        public override void OnReset()
        {
            if (pan != null) {
                pan.Value = 1;
            }
        }
    }
}