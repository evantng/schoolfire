using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;
using BehaviorDesigner.Runtime.Tasks.PlayMaker;

namespace BehaviorDesigner.Runtime
{
    public static class BehaviorManager_PlayMaker
    {
        public static void PlayMakerFinished(this BehaviorManager behaviorManager, HutongGames.PlayMaker.Fsm playMakerFSM, TaskStatus status)
        {
            if (behaviorManager == null) {
                return;
            }
            var behaviorTree = behaviorManager.treeForObject(playMakerFSM);
            if (behaviorTree != null) {
                for (int i = 0; i < behaviorManager.stackCount(behaviorTree); ++i) {
                    var task = behaviorManager.taskWithTreeAndStackIndex(behaviorTree, i);
                    if (task is StartFSM) {
                        var playMakerTask = task as StartFSM;
                        if (playMakerTask.PlayMakerFSM.Fsm.Equals(playMakerFSM)) {
                            playMakerTask.PlayMakerFinished(status);
                            StopPlayMaker(playMakerFSM, playMakerTask);
                            break;
                        }
                    }
                }
            }
        }

        public static bool StopPlayMaker(object playMakerObject, StartFSM playMakerTask)
        {
            var playMakerFSM = playMakerObject as HutongGames.PlayMaker.Fsm;
            if (playMakerFSM == null) {
                return false;
            }

            if (playMakerTask != null) {
                if (!playMakerTask.endEventName.Equals("")) {
                    playMakerFSM.Event(playMakerTask.endEventName);
                }

                if (playMakerTask.resetOnComplete) {
                    bool prevRestartOnEnable = playMakerFSM.RestartOnEnable;
                    if (!playMakerFSM.RestartOnEnable) {
                        playMakerFSM.RestartOnEnable = true;
                    }
                    // Enable/Disable PlayMaker to force it to restart from the beginning
                    playMakerFSM.Owner.enabled = false;
                    playMakerFSM.Owner.enabled = true;

                    playMakerFSM.RestartOnEnable = prevRestartOnEnable;
                }
            }

            return true;
        }
    }
}