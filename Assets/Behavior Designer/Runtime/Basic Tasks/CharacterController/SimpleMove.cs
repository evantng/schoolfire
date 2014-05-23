using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

namespace BehaviorDesigner.Runtime.Tasks.Basic.UnityCharacterController
{
    [TaskCategory("Basic/CharacterController")]
    [TaskDescription("Moves the character with speed. Returns Success.")]
    public class SimpleMove : Action
    {
        [Tooltip("The speed of the movement")]
        public SharedVector3 speed;

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

            characterController.SimpleMove(speed.Value);

            return TaskStatus.Success;
        }

        public override void OnReset()
        {
            if (speed != null) {
                speed.Value = Vector3.zero;
            }
        }
    }
}