using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

namespace BehaviorDesigner.Runtime.Tasks.Basic.UnityCharacterController
{
    [TaskCategory("Basic/CharacterController")]
    [TaskDescription("Sets the radius of the CharacterController. Returns Success.")]
    public class SetRadius : Action
    {
        [Tooltip("The radius of the CharacterController")]
        public SharedFloat radius;

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

            characterController.radius = radius.Value;

            return TaskStatus.Success;
        }

        public override void OnReset()
        {
            if (radius != null) {
                radius.Value = 0;
            }
        }
    }
}