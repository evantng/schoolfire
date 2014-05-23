using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

namespace BehaviorDesigner.Runtime.Tasks.Basic.UnitySphereCollider
{
    [TaskCategory("Basic/SphereCollider")]
    [TaskDescription("Stores the radius of the SphereCollider. Returns Success.")]
    public class GetRadius : Action
    {
        [Tooltip("The radius of the SphereCollider")]
        public SharedFloat storeValue;

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

            storeValue.Value = sphereCollider.radius;

            return TaskStatus.Success;
        }

        public override void OnReset()
        {
            if (storeValue != null) {
                storeValue.Value = 0;
            }
        }
    }
}