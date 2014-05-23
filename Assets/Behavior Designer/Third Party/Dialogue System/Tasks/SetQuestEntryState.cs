using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using PixelCrushers.DialogueSystem;

namespace BehaviorDesigner.Runtime.Tasks.DialugeSystem
{
    [TaskDescription("Sets the state of a quest entry in a quest.")]
    [TaskCategory("Dialogue System")]
    [HelpURL("http://www.opsive.com/assets/BehaviorDesigner/documentation.php?id=61")]
    [TaskIcon("DialogueSystemIcon.png")]
    public class SetQuestEntryState : Action
    {
        [Tooltip("The name of the quest")]
        public SharedString questEntryName;
        [Tooltip("The quest entry number (from 1)")]
        public SharedInt questEntryNumber;
        [Tooltip("The quest state (unassigned, active, success, or failure)")]
        public SharedString state;

        public override TaskStatus OnUpdate()
        {
            if (questEntryName == null || string.IsNullOrEmpty(questEntryName.Value)) {
                Debug.LogWarning("SetEntryQuestState Task: Quest Entry Name is null or empty");
                return TaskStatus.Failure;
            } else if (questEntryNumber == null) {
                Debug.LogWarning("SetEntryQuestState Task: Quest Entry Number is null");
                return TaskStatus.Failure;
            } else if (state == null) {
                Debug.LogWarning("SetEntryQuestState Task: State is null");
                return TaskStatus.Failure;
            }
            QuestLog.SetQuestEntry(questEntryName.Value, Mathf.Max(1, questEntryNumber.Value), state.Value.ToLower());
            return TaskStatus.Success;
        }

        public override void OnReset()
        {
            if (questEntryName != null)
                questEntryName.Value = "";
            if (questEntryNumber != null)
                questEntryNumber.Value = 0;
            if (state != null)
                state.Value = "";
        }
    }
}