using System;
using UnityEngine;
using HutongGames.PlayMaker;

namespace PixelCrushers.DialogueSystem.PlayMaker {
	
	[ActionCategory("Dialogue System")]
	[Tooltip("Sets the state of a quest.")]
	public class SetQuestState : FsmStateAction {
		
		[RequiredField]
		[Tooltip("The name of the quest")]
		public FsmString questName;
		
		[RequiredField]
		[Tooltip("The quest state (unassigned, active, success, or failure)")]
		public FsmString state;
		
		public override void Reset() {
			if (questName != null) questName.Value = string.Empty;
			if (state != null) state.Value = string.Empty;
		}
		
		public override void OnEnter() {
			if (PlayMakerTools.IsValueAssigned(questName)) {
				QuestLog.SetQuestState(questName.Value, QuestLog.StringToState(state.Value.ToLower()));
			} else {
				LogError(string.Format("{0}: Quest Name is null or blank.", DialogueDebug.Prefix));
			}
			Finish();
		}
		
	}
	
}