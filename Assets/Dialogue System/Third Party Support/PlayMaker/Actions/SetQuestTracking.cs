using System;
using UnityEngine;
using HutongGames.PlayMaker;

namespace PixelCrushers.DialogueSystem.PlayMaker {
	
	[ActionCategory("Dialogue System")]
	[Tooltip("Enables or disables tracking of a quest.")]
	public class SetQuestTracking : FsmStateAction {
		
		[RequiredField]
		[Tooltip("The name of the quest")]
		public FsmString questName;
		
		[RequiredField]
		[Tooltip("The track  state")]
		public FsmBool state;
		
		public override void Reset() {
			if (questName != null) questName.Value = string.Empty;
			if (state != null) state.Value = false;
		}
		
		public override void OnEnter() {
			if (PlayMakerTools.IsValueAssigned(questName)) {
				QuestLog.SetQuestTracking(questName.Value, state.Value);
			} else {
				LogError(string.Format("{0}: Quest Name is null or blank.", DialogueDebug.Prefix));
			}
			Finish();
		}
		
	}
	
}