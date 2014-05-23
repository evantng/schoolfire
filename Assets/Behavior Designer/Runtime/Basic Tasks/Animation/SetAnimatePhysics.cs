using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

namespace BehaviorDesigner.Runtime.Tasks.Basic.UnityAnimation
{
    [TaskCategory("Basic/Animation")]
    [TaskDescription("Sets animate physics to the specified value. Returns Success.")]
    public class SetAnimatePhysics : Action
    {
        [Tooltip("Are animations executed in the physics loop?")]
        public SharedBool animatePhysics;

        public override TaskStatus OnUpdate()
        {
            if (animation == null) {
                Debug.LogWarning("Animation is null");
                return TaskStatus.Failure;
            }

            animation.animatePhysics = animatePhysics.Value;

            return TaskStatus.Success;
        }

        public override void OnReset()
        {
            if (animatePhysics != null) {
                animatePhysics.Value = false;
            }
        }
    }
}