using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

namespace BehaviorDesigner.Runtime.Tasks.Basic.UnityAudioSource
{
    [TaskCategory("Basic/AudioSource")]
    [TaskDescription("Sets the loop value of the AudioSource. Returns Success.")]
    public class SetLoop : Action
    {
        [Tooltip("The loop value of the AudioSource")]
        public SharedBool loop;

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

            audioSource.loop = loop.Value;

            return TaskStatus.Success;
        }

        public override void OnReset()
        {
            if (loop != null) {
                loop.Value = false;
            }
        }
    }
}