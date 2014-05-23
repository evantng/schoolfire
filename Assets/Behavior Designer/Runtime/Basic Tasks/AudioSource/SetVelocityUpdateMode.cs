using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

namespace BehaviorDesigner.Runtime.Tasks.Basic.UnityAudioSource
{
    [TaskCategory("Basic/AudioSource")]
    [TaskDescription("Sets the rolloff mode of the AudioSource. Returns Success.")]
    public class SetVelocityUpdateMode : Action
    {
        [Tooltip("The velocity update mode of the AudioSource")]
        public AudioVelocityUpdateMode velocityUpdateMode;

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

            audioSource.velocityUpdateMode = velocityUpdateMode;

            return TaskStatus.Success;
        }

        public override void OnReset()
        {
            velocityUpdateMode = AudioVelocityUpdateMode.Auto;
        }
    }
}