using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

namespace BehaviorDesigner.Runtime.Tasks.Basic.UnitySphereCollider
{
    [TaskCategory("Basic/SphereCollider")]
    [TaskDescription("Sets the center of the SphereCollider. Returns Success.")]
    public class SetCenter : Action
    {
        [Tooltip("The center of the SphereCollider")]
        public SharedVector3 center;

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

            sphereCollider.center = center.Value;

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