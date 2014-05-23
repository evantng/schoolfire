using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

namespace BehaviorDesigner.Samples.DialogueSystem
{
    [TaskDescription("Move towards the specified position. The position can either be specified by a transform or position. If the transform " +
                     "is used then the position will not be used.")]
    [TaskCategory("Dialogue System")]
    public class MoveTowards2D : Action
    {
        [Tooltip("The speed of the agent")]
        public SharedFloat speed;
        [Tooltip("The agent has arrived when the square magnitude is less than this value")]
        public float arriveDistance = 0.1f;
        [Tooltip("The transform that the agent is moving towards")]
        public SharedTransform targetTransform;
        [Tooltip("If target is null then use the target position")]
        public SharedVector3 targetPosition;

        public override void OnStart()
        {
            if ((targetTransform == null || targetTransform.Value == null) && targetPosition == null) {
                Debug.LogError("Error: A MoveTowards target value is not set.");
                targetPosition = new SharedVector3(); // create a new SharedVector3 to prevent repeated errors
            }
        }

        public override TaskStatus OnUpdate()
        {
            var position = target();
            // Return a task status of success once we've reached the target
            if (Vector3.SqrMagnitude(transform.position - position) < arriveDistance) {
                return TaskStatus.Success;
            }
            // We haven't reached the target yet so keep moving towards it
            transform.position = Vector3.MoveTowards(transform.position, position, speed.Value * Time.deltaTime);
            // Face the target position
            Vector3 scale = transform.localScale;
            scale.x = (position.x > transform.position.x ? 1 : -1) * Mathf.Abs(scale.x);
            transform.localScale = scale;
            return TaskStatus.Running;
        }

        // Return targetPosition if targetTransform is null
        private Vector3 target()
        {
            if (targetTransform == null || targetTransform.Value == null) {
                return targetPosition.Value;
            }
            return targetTransform.Value.position;
        }

        // Reset the public variables
        public override void OnReset()
        {
            arriveDistance = 0.1f;
        }
    }
}