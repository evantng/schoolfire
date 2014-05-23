using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

namespace BehaviorDesigner.Runtime.Tasks.Basic.UnityCharacterController
{
    [TaskCategory("Basic/CharacterController")]
    [TaskDescription("Sets the center of the CharacterController. Returns Success.")]
    public class SetCenter : Action
    {
        [Tooltip("The center of the CharacterController")]
        public SharedVector3 center;

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

            characterController.center = center.Value;

            return TaskStatus.Success;
        }

        public override void OnReset()
        {
            if (center != null) {
                center.Value = Vector3.zero;
            }
        }
    }
}