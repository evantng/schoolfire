using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

namespace BehaviorDesigner.Runtime.Tasks.Basic.UnitySphereCollider
{
    [TaskCategory("Basic/SphereCollider")]
    [TaskDescription("Stores the center of the SphereCollider. Returns Success.")]
    public class GetCenter : Action
    {
        [Tooltip("The center of the SphereCollider")]
        public SharedVector3 storeValue;

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

            storeValue.Value = sphereCollider.center;

            return TaskStatus.Success;
        }

        public override void OnReset()
        {
            if (storeValue != null) {
                storeValue.Value = Vector3.zero;
            }
        }
    }
}