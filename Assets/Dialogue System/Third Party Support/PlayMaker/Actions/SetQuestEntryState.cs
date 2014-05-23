using System;
using UnityEngine;
using HutongGames.PlayMaker;

namespace PixelCrushers.DialogueSystem.PlayMaker {
	
	[ActionCategory("Dialogue System")]
	[Tooltip("Sets the state of a quest entry in a quest.")]
	public class SetQuestEntryState : FsmStateAction {
		
		[RequiredField]
		[Tooltip("The name of the quest")]
		public FsmString questName;
		
		[RequiredField]
		[Tooltip("The quest entry number (from 1)")]
		public FsmInt entryNumber;
		
		[RequiredField]
		[Tooltip("The quest state (unassigned, active, success, or failure)")]
		public FsmString state;
		
		public override void Reset() {
			if (questName != null) questName.Value = string.Empty;
			if (entryNumber != null) entryNumber.Value = 0;
			if (state != null) state.Value = string.Empty;
		}
		
		public override void OnEnter() {
			if (PlayMakerTools.IsValueAssigned(questName)) {
				QuestLog.SetQuestEntryState(questName.Value, Mathf.Max (1, entryNumber.Value), QuestLog.StringToState(state.Value.ToLower()));
			} else {
				LogError(string.Format("{0}: Quest Name is null or blank.", DialogueDebug.Prefix));
			}
			Finish();
		}
		
	}
	
}