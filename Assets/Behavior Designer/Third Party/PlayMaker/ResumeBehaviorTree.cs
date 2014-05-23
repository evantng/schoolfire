using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

namespace HutongGames.PlayMaker.Action
{
    public class ResumeBehaviorTree : FsmStateAction
    {
        public FsmBool success;

        public override void Reset()
        {
            success = false;
        }
        
        public override void OnEnter()
        {
            BehaviorManager.instance.PlayMakerFinished(Fsm, (success.Value ? TaskStatus.Success : TaskStatus.Failure));

            Finish();
        }
    }
}