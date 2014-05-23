using System;
using UnityEngine;
using HutongGames.PlayMaker;

namespace PixelCrushers.DialogueSystem.PlayMaker {
	
	[ActionCategory("Dialogue System")]
	[Tooltip("Gets the description of a quest.")]
	public class GetQuestDescription : FsmStateAction {
		
		[RequiredField]
		[Tooltip("The name of the quest")]
		public FsmString questName;
		
		[Tooltip("Get the description for this quest state (unassigned, active, success, or failure) or leave blank for the current state")]
		public FsmString state;
		
		[UIHint(UIHint.Variable)]
		[Tooltip("Store the result in a String variable")]
		public FsmString storeResult;
		
		public override void Reset() {
			if (questName != null) questName.Value = string.Empty;
			if (state != null) state.Value = string.Empty;
			storeResult = null;
		}
		
		public override void OnEnter() {
			if ((questName == null) || (string.IsNullOrEmpty(questName.Value))) {
				LogError(string.Format("{0}: Quest Name is null or blank.", DialogueDebug.Prefix));
			} else if (storeResult != null) {
				storeResult.Value = ((state == null) || string.IsNullOrEmpty(state.Value)) 
					? QuestLog.GetQuestDescription(questName.Value)
					: QuestLog.GetQuestDescription(questName.Value, QuestLog.StringToState(state.Value.ToLower()));
			}
			Finish();
		}
		
	}
	
}