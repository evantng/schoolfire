using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

namespace BehaviorDesigner.Runtime.Tasks.Basic.UnityRigidbody
{
    [TaskCategory("Basic/Rigidbody")]
    [TaskDescription("Applies a force to the rigidbody that simulates explosion effects. Returns Success.")]
    public class AddExplosionForce : Action
    {
        [Tooltip("The force of the explosion")]
        public SharedFloat explosionForce;
        [Tooltip("The position of the explosion")]
        public SharedVector3 explosionPosition;
        [Tooltip("The radius of the explosion")]
        public SharedFloat explosionRadius;
        [Tooltip("Applies the force as if it was applied from beneath the object")]
        public float upwardsModifier = 0;
        [Tooltip("The type of force")]
        public ForceMode forceMode = ForceMode.Force;

        public override TaskStatus OnUpdate()
        {
            if (rigidbody == null) {
                Debug.LogWarning("Rigidbody is null");
                return TaskStatus.Failure;
            }

            rigidbody.AddExplosionForce(explosionForce.Value, explosionPosition.Value, explosionRadius.Value, upwardsModifier, forceMode);

            return TaskStatus.Success;
        }

        public override void OnReset()
        {
            if (explosionForce != null) {
                explosionForce.Value = 0;
            }
            if (explosionPosition != null) {
                explosionPosition.Value = Vector3.zero;
            }
            if (explosionRadius != null) {
                explosionRadius.Value = 0;
            }
            upwardsModifier = 0;
            forceMode = ForceMode.Force;
        }
    }
}