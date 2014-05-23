using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

namespace BehaviorDesigner.Runtime.Tasks.Basic.UnityCharacterController
{
    [TaskCategory("Basic/CharacterController")]
    [TaskDescription("Sets the height of the CharacterController. Returns Success.")]
    public class SetHeight : Action
    {
        [Tooltip("The height of the CharacterController")]
        public SharedFloat height;

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

            characterController.height = height.Value;

            return TaskStatus.Success;
        }

        public override void OnReset()
        {
            if (height != null) {
                height.Value = 0;
            }
        }
    }
}