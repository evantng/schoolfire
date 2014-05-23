using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [ActionCategory(ActionCategory.Vector3)]
    [Tooltip("Retruns the dot product between the forward direction of the Game Object and the Vector Variable")]
    public class Vector3Dot : FsmStateAction
    {
        [RequiredField]
        public FsmOwnerDefault gameObject;
        [RequiredField]
        [UIHint(UIHint.Variable)]
        public FsmVector3 vector3Variable;
        [RequiredField]
        [UIHint(UIHint.Variable)]
        public FsmFloat storeResult;

        public override void Reset()
        {
            gameObject = null;
            vector3Variable = null;
            storeResult = null;
        }

        public override void OnEnter()
        {
            var go = Fsm.GetOwnerDefaultTarget(gameObject);
            if (go == null) return;

            storeResult.Value = Vector3.Dot(go.transform.forward, vector3Variable.Value);
            
            Finish();
        }
    }
}

