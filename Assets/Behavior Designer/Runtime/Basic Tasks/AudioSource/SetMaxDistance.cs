using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

namespace BehaviorDesigner.Runtime.Tasks.Basic.UnityAudioSource
{
    [TaskCategory("Basic/AudioSource")]
    [TaskDescription("Sets the max distance value of the AudioSource. Returns Success.")]
    public class SetMaxDistance : Action
    {
        [Tooltip("The max distance value of the AudioSource")]
        public SharedFloat maxDistance;

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

            audioSource.maxDistance = maxDistance.Value;

            return TaskStatus.Success;
        }

        public override void OnReset()
        {
            if (maxDistance != null) {
                maxDistance.Value = 1;
            }
        }
    }
}