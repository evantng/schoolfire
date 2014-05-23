using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

namespace BehaviorDesigner.Runtime.Tasks.Basic.UnityAudioSource
{
    [TaskCategory("Basic/AudioSource")]
    [TaskDescription("Sets the min distance value of the AudioSource. Returns Success.")]
    public class SetMinDistance : Action
    {
        [Tooltip("The min distance value of the AudioSource")]
        public SharedFloat minDistance;

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

            audioSource.minDistance = minDistance.Value;

            return TaskStatus.Success;
        }

        public override void OnReset()
        {
            if (minDistance != null) {
                minDistance.Value = 1;
            }
        }
    }
}