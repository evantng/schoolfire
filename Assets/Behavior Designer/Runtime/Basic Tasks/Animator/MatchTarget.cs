using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

namespace BehaviorDesigner.Runtime.Tasks.Basic.UnityAnimator
{
    [TaskCategory("Basic/Animator")]
    [TaskDescription("Automatically adjust the gameobject position and rotation so that the AvatarTarget reaches the matchPosition when the current state is at the specified progress. Returns Success.")]
    public class MatchTarget : Action
    {
        [Tooltip("The position we want the body part to reach")]
        public SharedVector3 matchPosition;
        [Tooltip("The rotation in which we want the body part to be")]
        public SharedQuaternion matchRotation;
        [Tooltip("The body part that is involved in the match")]
        public AvatarTarget targetBodyPart;
        [Tooltip("Weights for matching position")]
        public Vector3 weightMaskPosition;
        [Tooltip("Weights for matching rotation")]
        public float weightMaskRotation;
        [Tooltip("Start time within the animation clip")]
        public float startNormalizedTime;
        [Tooltip("End time within the animation clip")]
        public float targetNormalizedTime = 1;

        private Animator animator;

        public override void OnAwake()
        {
            animator = gameObject.GetComponent<Animator>();
        }

        public override TaskStatus OnUpdate()
        {
            if (animator == null) {
                Debug.LogWarning("Animator is null");
                return TaskStatus.Failure;
            }

            animator.MatchTarget(matchPosition.Value, matchRotation.Value, targetBodyPart, new MatchTargetWeightMask(weightMaskPosition, weightMaskRotation), startNormalizedTime, targetNormalizedTime);

            return TaskStatus.Success;
        }

        public override void OnReset()
        {
            if (matchPosition != null) {
                matchPosition.Value = Vector3.zero;
            }
            if (matchRotation != null) {
                matchRotation.Value = Quaternion.identity;
            }
            targetBodyPart = AvatarTarget.Root;
            weightMaskPosition = Vector3.zero;
            weightMaskRotation = 0;
            startNormalizedTime = 0;
            targetNormalizedTime = 1;
        }
    }
}