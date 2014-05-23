using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

namespace BehaviorDesigner.Runtime.Tasks.Basic.UnityAnimation
{
    [TaskCategory("Basic/Animation")]
    [TaskDescription("Stores the animate physics value. Returns Success.")]
    public class GetAnimatePhysics : Action
    {
        [Tooltip("Are the if animations are executed in the physics loop?")]
        public SharedBool storeValue;

        public override TaskStatus OnUpdate()
        {
            if (animation == null) {
                Debug.LogWarning("Animation is null");
                return TaskStatus.Failure;
            }

            storeValue.Value = animation.animatePhysics;

            return TaskStatus.Success;
        }

        public override void OnReset()
        {
            if (storeValue != null) {
                storeValue.Value = false;
            }
        }
    }
}