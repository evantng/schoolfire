using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using PixelCrushers.DialogueSystem;

namespace BehaviorDesigner.Runtime.Tasks.DialugeSystem
{
    [TaskDescription("Gets the state of a quest.")]
    [TaskCategory("Dialogue System")]
    [HelpURL("http://www.opsive.com/assets/BehaviorDesigner/documentation.php?id=59")]
    [TaskIcon("DialogueSystemIcon.png")]
    public class GetQuestState : Action
    {
        [Tooltip("The name of the quest")]
        public SharedString questName;
        [Tooltip("Store the result in a String variable ('unassigned', 'active', 'success', or 'failure')")]
        public SharedString storeResult;

        public override TaskStatus OnUpdate()
        {
            if ((questName == null) || (string.IsNullOrEmpty(questName.Value))) {
                Debug.LogWarning("QuestState Task: Quest Name is null or empty");
                return TaskStatus.Failure;
            }
            var questState = QuestLog.GetQuestState(questName.Value);
            if (storeResult != null) {
                storeResult.Value = questState.ToString().ToLower();
            }
            return TaskStatus.Success;
        }


        public override void OnReset()
        {
            if (questName != null)
                questName.Value = "";
            if (storeResult != null)
                storeResult.Value = "";
        }
    }
}