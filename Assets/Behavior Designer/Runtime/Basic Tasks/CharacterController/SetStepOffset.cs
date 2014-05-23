using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

namespace BehaviorDesigner.Runtime.Tasks.Basic.UnityCharacterController
{
    [TaskCategory("Basic/CharacterController")]
    [TaskDescription("Sets the step offset of the CharacterController. Returns Success.")]
    public class SetStepOffset : Action
    {
        [Tooltip("The step offset of the CharacterController")]
        public SharedFloat stepOffset;

        private CharacterController characterController;

        public override void OnAwake()
        {
            characterController = gameObject.GetComponent<CharacterController>();
        }

        public override TaskStatus OnUpdate()
        {
            if (characterController == null) {
                Debug.LogWarning("CharacterController is null");
                return TaskStatus.Failure;
            }

            characterController.stepOffset = stepOffset.Value;

            return TaskStatus.Success;
        }

        public override void OnReset()
        {
            if (stepOffset != null) {
                stepOffset.Value = 0;
            }
        }
    }
}