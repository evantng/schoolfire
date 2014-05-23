using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

namespace BehaviorDesigner.Runtime.Tasks.Basic.UnityAudioSource
{
    [TaskCategory("Basic/AudioSource")]
    [TaskDescription("Sets the pan level value of the AudioSource. Returns Success.")]
    public class SetPanLevel : Action
    {
        [Tooltip("The pan level value of the AudioSource")]
        public SharedFloat panLevel;

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

            audioSource.panLevel = panLevel.Value;

            return TaskStatus.Success;
        }

        public override void OnReset()
        {
            if (panLevel != null) {
                panLevel.Value = 1;
            }
        }
    }
}