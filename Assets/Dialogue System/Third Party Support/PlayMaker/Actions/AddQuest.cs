using System;
using UnityEngine;
using HutongGames.PlayMaker;

namespace PixelCrushers.DialogueSystem.PlayMaker {
	
	[ActionCategory("Dialogue System")]
	[Tooltip("Adds a new quest to the quest system.")]
	public class AddQuest : FsmStateAction {
		
		[RequiredField]
		[Tooltip("The name of the quest")]
		public FsmString questName;
		
		[RequiredField]
		[Tooltip("The quest description")]
		public FsmString description;
		
		[Tooltip("The quest description to use when successfully completed")]
		public FsmString successDescription;
		
		[Tooltip("The quest description to use when completed in failure")]
		public FsmString failureDescription;
		
		[Tooltip("The quest state (unassigned, active, success, or failure)")]
		public FsmString state;
		
		public override void Reset() {
			if (questName != null) questName.Value = string.Empty;
			if (description != null) description.Value = string.Empty;
			if (successDescription != null) successDescription.Value = string.Empty;
			if (failureDescription != null) failureDescription.Value = string.Empty;
			if (state != null) state.Value = string.Empty;
		}
		
		public override void OnEnter() {
			QuestLog.AddQuest(questName.Value, description.Value, QuestLog.StringToState(state.Value));
			if (!string.IsNullOrEmpty(successDescription.Value)) QuestLog.SetQuestDescription(questName.Value, QuestState.Success, successDescription.Value);
			if (!string.IsNullOrEmpty(failureDescription.Value)) QuestLog.SetQuestDescription(questName.Value, QuestState.Failure, failureDescription.Value);
			QuestLog.SetQuestState(questName.Value, QuestLog.StringToState(state.Value));
			Finish();
		}
		
	}
	
}