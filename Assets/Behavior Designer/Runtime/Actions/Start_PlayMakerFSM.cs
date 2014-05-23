using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks.PlayMaker;

namespace BehaviorDesigner.Runtime.Tasks
{
    [TaskDescription("Start executing a PlayMaker FSM. The task will stay in a running state until PlayMaker FSM has returned success or failure. " +
                     "The PlayMaker FSM must contain a Behavior Listener state with the specified event name to start executing and finish with a Resume From PlayMaker action.")]
    [HelpURL("http://www.opsive.com/assets/BehaviorDesigner/documentation.php?id=18")]
    [TaskIcon("PlayMakerIcon.png")]
    [System.Obsolete("Start_PlayMakerFSM is deprecated. Use StartFSM instead.")]
    public class Start_PlayMakerFSM : StartFSM
    {
        public override void OnAwake()
        {
            base.OnAwake();

            Debug.LogWarning("Start_PlayMakerFSM is deprecated. Use StartFSM instead.");
        }
    }
}