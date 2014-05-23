using UnityEngine;
using PixelCrushers.DialogueSystem;
using BehaviorDesigner.Runtime.Tasks;

namespace BehaviorDesigner.Runtime.Tasks.DialugeSystem
{
    [TaskDescription("Stops the current conversation.")]
    [TaskCategory("Dialogue System")]
    [HelpURL("http://www.opsive.com/assets/BehaviorDesigner/documentation.php?id=64")]
    [TaskIcon("DialogueSystemIcon.png")]
    public class StopConversation : Action
    {
        public override TaskStatus OnUpdate()
        {
            DialogueManager.StopConversation();
            return TaskStatus.Success;
        }
    }
}