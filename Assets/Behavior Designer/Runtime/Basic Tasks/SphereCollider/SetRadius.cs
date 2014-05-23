using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

namespace BehaviorDesigner.Runtime.Tasks.Basic.UnitySphereCollider
{
    [TaskCategory("Basic/SphereCollider")]
    [TaskDescription("Sets the radius of the SphereCollider. Returns Success.")]
    public class SetRadius : Action
    {
        [Tooltip("The radius of the SphereCollider")]
        public SharedFloat radius;

        private SphereCollider sphereCollider;

        public override void OnAwake()
        {
            sphereCollider = gameObject.GetComponent<SphereCollider>();
        }

        public override TaskStatus OnUpdate()
        {
            if (sphereCollider == null) {
                Debug.LogWarning("SphereCollider is null");
                return TaskStatus.Failure;
            }

            sphereCollider.radius = radius.Value;

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