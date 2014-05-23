using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

namespace BehaviorDesigner.Samples.DialogueSystem
{
    [TaskDescription("Fires the bazooka by instantiating a rocket.")]
    [TaskCategory("Dialogue System")]
    public class FireBazooka : Action
    {
        [Tooltip("The bazooka's rocket")]
        public GameObject rocket;
        [Tooltip("The target of the rocket")]
        public SharedTransform target;

        public override TaskStatus OnUpdate()
        {
            if (target.Value == null) {
                Debug.LogWarning("Unable to instantiate rocket. Target is null");
                return TaskStatus.Failure;
            }

            // looking left
            Rocket rocketInstance;
            if (transform.localScale.x > 0) {
				rocketInstance = (Instantiate(rocket, transform.position, Quaternion.Euler(Vector3.zero)) as GameObject).GetComponent<Rocket>();
            } else { // looking right
                rocketInstance = (Instantiate(rocket, transform.position, Quaternion.Euler(new Vector3(0, 0, 180f))) as GameObject).GetComponent<Rocket>();
            }

            rocketInstance.target = target.Value;
            return TaskStatus.Success;
        }

        // Reset the public variables
        public override void OnReset()
        {
            rocket = null;
            target.Value = null;
        }
    }
}

