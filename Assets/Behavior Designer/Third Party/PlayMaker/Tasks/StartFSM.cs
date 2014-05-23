using UnityEngine;
using BehaviorDesigner.Runtime;

namespace BehaviorDesigner.Runtime.Tasks.PlayMaker
{
    [TaskDescription("Start executing a PlayMaker FSM. The task will stay in a running state until PlayMaker FSM has returned success or failure. " +
                     "The PlayMaker FSM must contain a Behavior Listener state with the specified event name to start executing and finish with a Resume From PlayMaker action.")]
    [HelpURL("http://www.opsive.com/assets/BehaviorDesigner/documentation.php?id=18")]
    [TaskIcon("PlayMakerIcon.png")]
    [TaskCategory("PlayMaker")]
    public class StartFSM : Action
    {
        [Tooltip("The GameObject that the PlayMaker FSM component is attached to")]
        public GameObject playMakerGameObject;
        [Tooltip("The name of the FSM component. This allows you to have multiple FSM components on a single GameObject")]
        public string FsmName = "FSM";
        [Tooltip("The name of the event to fire to start executing the FSM within PlayMaker")]
        public string startEventName = "StartFSM";
        [Tooltip("The name of the event to fire to pause executing the FSM within PlayMaker")]
        public string pauseEventName = "";
        [Tooltip("The name of the event to fire to resume executing the FSM within PlayMaker")]
        public string resumeEventName = "";
        [Tooltip("The name of the event to fire to end executing the FSM within PlayMaker")]
        public string endEventName = "";
        [Tooltip("When the PlayMaker FSM is complete should we restart the FSM back to its original state? This variable is used by the Behavior Manager")]
        public bool resetOnComplete = false;

        // A cache of the PlayMakerFSM to prevent having to look
        private PlayMakerFSM playMakerFSM;
        public PlayMakerFSM PlayMakerFSM { get { return playMakerFSM; } }
        // The return status of the FSM after it has finished executing
        private TaskStatus status;

        public override void OnAwake()
        {
            // Find the correct PlayMakerFSM based on the name.
            var playMakerComponents = playMakerGameObject != null ? playMakerGameObject.GetComponents<PlayMakerFSM>() : gameObject.GetComponents<PlayMakerFSM>();
            if (playMakerComponents != null && playMakerComponents.Length > 0) {
                playMakerFSM = playMakerComponents[0];
                //  We don't need the FsmName if there is only one PlayMakerFSM component
                if (playMakerComponents.Length > 1) {
                    for (int i = 0; i < playMakerComponents.Length; ++i) {
                        if (playMakerComponents[i].FsmName.Equals(FsmName)) {
                            // Cache the result when we have a match and stop looping.
                            playMakerFSM = playMakerComponents[i];
                            break;
                        }
                    }
                }
            }

            // We can't do much if there isn't a PlayMakerFSM.
            if (playMakerFSM == null) {
                Debug.LogError(string.Format("Unable to find PlayMaker FSM {0}{1}", FsmName, (playMakerGameObject != null ? string.Format(" attached to {0}", playMakerGameObject.name) : "")));
            }
        }

        public override void OnStart()
        {
            // Tell the Behavior Manager that we are running a PlayMaker FSM instance.
            if (playMakerFSM != null && BehaviorManager.instance.mapObjectToTree(playMakerFSM.Fsm, Owner, BehaviorManager.ThirdPartyObjectType.PlayMaker)) {
                status = TaskStatus.Running;
                // Fire an event to start PlayMaker.
                playMakerFSM.Fsm.Event(startEventName);
            } else {
                // If something went wrong then return failure.
                status = TaskStatus.Failure;
            }
        }

        public override TaskStatus OnUpdate()
        {
            // We are returning the same status until we hear otherwise.
            return status;
        }

        public override void OnPause(bool paused)
        {
            if (playMakerFSM != null) {
                if (paused && !pauseEventName.Equals("")) {
                    playMakerFSM.Fsm.Event(pauseEventName);
                } else if (!paused && !resumeEventName.Equals("")) {
                    playMakerFSM.Fsm.Event(resumeEventName);
                }
            }
        }

        // The PlayMaker action ResumeFromPlayMaker will call this function when it has completed. 
        public void PlayMakerFinished(TaskStatus playMakerStatus)
        {
            // Update the status with what PlayMaker returned.
            status = playMakerStatus;
        }

        public override void OnReset()
        {
            // Reset the public properties back to their original values
            playMakerGameObject = null;
            FsmName = "FSM";
            startEventName = "StartFSM";
            endEventName = pauseEventName = resumeEventName = "";
            resetOnComplete = false;
        }
    }
}
