using UnityEngine;

namespace HutongGames.PlayMaker.Action
{
    public class ObjectDirection : FsmStateAction
    {
        [RequiredField]
        public FsmOwnerDefault gameObject;
        [RequiredField]
        public FsmGameObject toGameObject;
        [RequiredField]
        [UIHint(UIHint.Variable)]
        public FsmVector3 storeResult;

        public override void Reset()
        {
            gameObject = null;
            toGameObject = null;
            storeResult = null;
        }

        public override void OnEnter()
        {
            var go = Fsm.GetOwnerDefaultTarget(gameObject);
            if (go == null) return;

            var toGO = toGameObject.Value;
            if (toGO == null) return;

            storeResult.Value = (toGO.transform.position - go.transform.position);

            Finish();
        }
    }
}