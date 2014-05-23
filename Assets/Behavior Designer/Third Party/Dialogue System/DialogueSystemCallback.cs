using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using PixelCrushers.DialogueSystem;

namespace BehaviorDesigner.Runtime.Tasks.DialugeSystem
{
    public class DialogueSystemCallback : MonoBehaviour
    {
        // The last player response
        private string lastLine = "";

        public void OnConversationStart(Transform actor)
        {
            lastLine = "";
        }

        public void OnConversationLine(Subtitle subtitle)
        {
            // Save the text of the last player response so another task can check the response.
            bool isPlayerLine = DialogueManager.MasterDatabase.IsPlayerID(subtitle.speakerInfo.id);
            if (isPlayerLine) {
                lastLine = subtitle.formattedText.text;
            }
        }

        public void OnConversationCancelled(Transform actor)
        {
            // Return failure if the conversation was cancelled. Record the last line so another task can check what the last response was.
            BehaviorManager.instance.DialogueSystemFinished(gameObject.transform, TaskStatus.Failure, lastLine);
        }

        public void OnConversationEnd(Transform actor)
        {
            // Always return success if the conversation ends without being cancelled. Record the last line so another task can check the response.
            BehaviorManager.instance.DialogueSystemFinished(gameObject.transform, TaskStatus.Success, lastLine);
        }

        public void OnSequenceEnd(Transform actor)
        {
            // Always return success when the sequence ends
            BehaviorManager.instance.DialogueSystemFinished(actor != null ? actor : gameObject.transform, TaskStatus.Success, "");
        }
    }
}