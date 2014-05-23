using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

namespace BehaviorDesigner.Runtime.Tasks.Basic.UnityAudioSource
{
    [TaskCategory("Basic/AudioSource")]
    [TaskDescription("Sets the spread value of the AudioSource. Returns Success.")]
    public class SetSpread : Action
    {
        [Tooltip("The spread value of the AudioSource")]
        public SharedFloat spread;

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

            audioSource.spread = spread.Value;

            return TaskStatus.Success;
        }

        public override void OnReset()
        {
            if (spread != null) {
                spread.Value = 1;
            }
        }
    }
}