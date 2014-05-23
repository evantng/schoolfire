using System;
using UnityEngine;
using HutongGames.PlayMaker;

namespace PixelCrushers.DialogueSystem.PlayMaker {
	
	[ActionCategory("Dialogue System")]
	[Tooltip("Checks if a quest is abandonable.")]
	public class IsQuestAbandonable : FsmStateAction {
		
		[RequiredField]
		[Tooltip("The name of the quest")]
		public FsmString questName;
		
		[UIHint(UIHint.Variable)]
		[Tooltip("Store the result in a Bool variable")]
		public FsmBool storeResult;

		public FsmEvent trueEvent;
		public FsmEvent falseEvent;

		public override void Reset() {
			if (questName != null) questName.Value = string.Empty;
			storeResult = null;
		}
		
		public override void OnEnter() {
			if ((questName == null) || (string.IsNullOrEmpty(questName.Value))) {
				LogError(string.Format("{0}: Quest Name is null or blank.", DialogueDebug.Prefix));
			} else {
				bool result = QuestLog.IsQuestAbandonable(questName.Value);
				if (storeResult != null) storeResult.Value = result;
				Fsm.Event(result ? trueEvent : falseEvent);
			}
			Finish();
		}
		
	}
	
}