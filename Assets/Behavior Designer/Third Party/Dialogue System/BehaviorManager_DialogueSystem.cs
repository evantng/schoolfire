using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;
using BehaviorDesigner.Runtime.Tasks.DialugeSystem;
using PixelCrushers.DialogueSystem;

namespace BehaviorDesigner.Runtime
{
    public static class BehaviorManager_DialogueSystem
    {
        public static void DialogueSystemFinished(this BehaviorManager behaviorManager, Transform actor, TaskStatus status, string lastLine)
        {
            if (behaviorManager == null) {
                return;
            }
            var behaviorTree = behaviorManager.treeForObject(actor);
            if (behaviorTree != null) {
                for (int i = 0; i < behaviorManager.stackCount(behaviorTree); ++i) {
                    var task = behaviorManager.taskWithTreeAndStackIndex(behaviorTree, i);
                    if (task is StartConversation) {
                        var startConversationTask = task as StartConversation;
                        startConversationTask.ConversationComplete(status, lastLine);
                        break;
                    } else if (task is StartSequence) {
                        var startSequenceTask = task as StartSequence;
                        startSequenceTask.SequenceComplete(status);
                    }
                }
            }
        }

        public static bool StopDialogueSystem(object actor, Task dialogueSystemTask)
        {
            var actorTransform = actor as Transform;
            if (actorTransform == null) {
                return false;
            }

            if (dialogueSystemTask != null) {
                if (dialogueSystemTask is StartConversation) {
                    DialogueManager.StopConversation();
                } else if (dialogueSystemTask is StartSequence) {
                    DialogueManager.StopSequence((dialogueSystemTask as StartSequence).storeResult.Value as Sequencer);
                }
            }

            return true;
        }
    }
}