using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

namespace BehaviorDesigner.Runtime.Tasks.Basic.UnityCharacterController
{
    [TaskCategory("Basic/CharacterController")]
    [TaskDescription("A more complex move function taking absolute movement deltas. Returns Success.")]
    public class Move : Action
    {
        [Tooltip("The amount to move")]
        public SharedVector3 motion;

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

            characterController.Move(motion.Value);

            return TaskStatus.Success;
        }

        public override void OnReset()
        {
            if (motion != null) {
                motion.Value = Vector3.zero;
            }
        }
    }
}