using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

namespace BehaviorDesigner.Runtime.Tasks.Basic.UnityCharacterController
{
    [TaskCategory("Basic/CharacterController")]
    [TaskDescription("Sets the slope limit of the CharacterController. Returns Success.")]
    public class SetSlopeLimit : Action
    {
        [Tooltip("The slope limit of the CharacterController")]
        public SharedFloat slopeLimit;

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

            characterController.slopeLimit = slopeLimit.Value;

            return TaskStatus.Success;
        }

        public override void OnReset()
        {
            if (slopeLimit != null) {
                slopeLimit.Value = 0;
            }
        }
    }
}