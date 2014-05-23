using System;
using UnityEngine;
using HutongGames.PlayMaker;

namespace PixelCrushers.DialogueSystem.PlayMaker {
	
	[ActionCategory("Dialogue System")]
	[Tooltip("Gets the number of quest entries in a quest.")]
	public class GetQuestEntryCount : FsmStateAction {
		
		[RequiredField]
		[Tooltip("The name of the quest")]
		public FsmString questName;
		
		[RequiredField]
		[UIHint(UIHint.Variable)]
		[Tooltip("Store the result in an Int variable")]
		public FsmInt storeResult;

		public override void Reset() {
			if (questName != null) questName.Value = string.Empty;
			storeResult = null;
		}
		
		public override void OnEnter() {
			if (PlayMakerTools.IsValueAssigned(questName)) {
				if (storeResult != null) storeResult.Value = QuestLog.GetQuestEntryCount(questName.Value);
			} else {
				LogError(string.Format("{0}: Quest Name is null or blank.", DialogueDebug.Prefix));
			}
			Finish();
		}
		
	}
	
}