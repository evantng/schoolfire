using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using PixelCrushers.DialogueSystem;

namespace BehaviorDesigner.Runtime.Tasks.DialugeSystem
{
    [TaskDescription("Sets the state of a quest.")]
    [TaskCategory("Dialogue System")]
    [HelpURL("http://www.opsive.com/assets/BehaviorDesigner/documentation.php?id=62")]
    [TaskIcon("DialogueSystemIcon.png")]
    public class SetQuestState : Action
    {
        [Tooltip("The name of the quest")]
        public SharedString questName;
        [Tooltip("The quest state (unassigned, active, success, or failure)")]
        public SharedString state;

        public override TaskStatus OnUpdate()
        {
            if (questName == null || string.IsNullOrEmpty(questName.Value)) {
                Debug.LogWarning("SetQuestState Task: Quest Name is null or blank");
                return TaskStatus.Failure;
            }
            QuestLog.SetQuestState(questName.Value, QuestLog.StringToState(state.Value.ToLower()));
            return TaskStatus.Success;
        }

        public override void OnReset()
        {
            if (questName != null)
                questName.Value = "";
            if (state != null)
                state.Value = "";
        }
    }
}