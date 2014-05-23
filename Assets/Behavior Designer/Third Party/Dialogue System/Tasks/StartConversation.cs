using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using PixelCrushers.DialogueSystem;

namespace BehaviorDesigner.Runtime.Tasks.DialugeSystem
{
    [TaskDescription("Starts a conversation.")]
    [TaskCategory("Dialogue System")]
    [HelpURL("http://www.opsive.com/assets/BehaviorDesigner/documentation.php?id=57")]
    [TaskIcon("DialogueSystemIcon.png")]
    public class StartConversation : Action
    {
        [Tooltip("The conversation to start")]
        public SharedString conversation;
        [Tooltip("The primary participant in the conversation (e.g., the player)")]
        public SharedGameObject actor;
        [Tooltip("The other participant in the conversation (e.g., the NPC)")]
        public SharedGameObject conversant;
        [Tooltip("Should the behavior tree wait for the conversation to finish before moving onto the next task?")]
        public bool returnImmediately = false;
        [Tooltip("Store the last line selected within the conversation")]
        public SharedString lastLine;

        // The return status of the conversation after it has finished executing.
        private TaskStatus status;

        public override void OnStart()
        {
            string conversationTitle = (conversation != null) ? conversation.Value : string.Empty;
            var actorTransform = ((actor != null) && (actor.Value != null)) ? actor.Value.transform : null;
            var conversantTransform = ((conversant != null) && (conversant.Value != null)) ? conversant.Value.transform : null;
            status = TaskStatus.Failure; // assume failure

            if (actorTransform == null) {
                Debug.LogWarning("StartConversation Task: actor is null");
            } else if (string.IsNullOrEmpty(conversationTitle)) {
                Debug.LogWarning("StartConversation Task: conversation is empty");
            } else {
                if (returnImmediately || BehaviorManager.instance.mapObjectToTree(actorTransform, Owner, BehaviorManager.ThirdPartyObjectType.DialogueSystem)) {
                    DialogueManager.StartConversation(conversationTitle, actorTransform, conversantTransform);
                    status = returnImmediately ? TaskStatus.Success : TaskStatus.Running;
                }
            }
        }

        public override TaskStatus OnUpdate()
        {
            // We are returning the same status until we hear otherwise.
            return status;
        }

        // ConversationComplete will be called after the Dialogue System finishes its conversation. 
        public void ConversationComplete(TaskStatus taskStatus, string line)
        {
            lastLine.Value = line;
            // Update the status when the Dialogue System completes
            status = TaskStatus.Success;
        }

        public override void OnReset()
        {
            if (conversation != null)
                conversation.Value = "";
            if (actor != null)
                actor.Value = null;
            if (conversant != null)
                conversant.Value = null;
            returnImmediately = false;
            if (lastLine != null)
                lastLine.Value = "";
        }
    }
}