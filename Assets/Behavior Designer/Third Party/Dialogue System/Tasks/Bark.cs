using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using PixelCrushers.DialogueSystem;

namespace BehaviorDesigner.Runtime.Tasks.DialugeSystem
{
    [TaskDescription("Makes an NPC bark.")]
    [TaskCategory("Dialogue System")]
    [HelpURL("http://www.opsive.com/assets/BehaviorDesigner/documentation.php?id=56")]
    [TaskIcon("DialogueSystemIcon.png")]
    public class Bark : Action
    {
        [Tooltip("The conversation containing the bark lines")]
        public SharedString conversation;
        [Tooltip("The character speaking the bark")]
        public SharedGameObject speaker;
        [Tooltip("The character being barked at (optional)")]
        public SharedGameObject listener;

        public override TaskStatus OnUpdate()
        {
            var conversationTitle = (conversation != null) ? conversation.Value : string.Empty;
            var speakerTransform = ((speaker != null) && (speaker.Value != null)) ? speaker.Value.transform : null;
            var listenerTransform = ((listener != null) && (listener.Value != null)) ? listener.Value.transform : null;
            TaskStatus status = TaskStatus.Failure; // assume failure
            if (speakerTransform == null) {
                Debug.LogWarning("StartBark Task: speaker is null");
            } else if (string.IsNullOrEmpty(conversationTitle)) {
                Debug.LogWarning("StartBark Task: conversation title is empty");
            } else {
                if (listenerTransform != null) {
                    DialogueManager.Bark(conversationTitle, speakerTransform, listenerTransform);
                } else {
                    DialogueManager.Bark(conversationTitle, speakerTransform);
                }
                status = TaskStatus.Success;
            }
            return status;
        }

        public override void OnReset()
        {
            if (conversation != null)
                conversation.Value = "";
            if (speaker != null)
                speaker.Value = null;
            if (listener != null)
                listener.Value = null;
        }
    }
}