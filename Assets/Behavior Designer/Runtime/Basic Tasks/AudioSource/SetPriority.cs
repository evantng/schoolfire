using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

namespace BehaviorDesigner.Runtime.Tasks.Basic.UnityAudioSource
{
    [TaskCategory("Basic/AudioSource")]
    [TaskDescription("Sets the priority value of the AudioSource. Returns Success.")]
    public class SetPriority : Action
    {
        [Tooltip("The priority value of the AudioSource")]
        public SharedInt priority;

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

            audioSource.priority = priority.Value;

            return TaskStatus.Success;
        }

        public override void OnReset()
        {
            if (priority != null) {
                priority.Value = 1;
            }
        }
    }
}