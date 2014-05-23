using System;
using UnityEngine;
using HutongGames.PlayMaker;

namespace PixelCrushers.DialogueSystem.PlayMaker {
	
	[ActionCategory("Dialogue System")]
	[Tooltip("Gets the state of a quest.")]
	public class GetQuestState : FsmStateAction {
		
		[RequiredField]
		[Tooltip("The name of the quest")]
		public FsmString questName;
		
		[UIHint(UIHint.Variable)]
		[Tooltip("Store the result in a String variable ('unassigned', 'active', 'success', or 'failure')")]
		public FsmString storeResult;

		public FsmEvent unassignedStateEvent;
		public FsmEvent activeStateEvent;
		public FsmEvent successStateEvent;
		public FsmEvent failureStateEvent;
		
		public override void Reset() {
			if (questName != null) questName.Value = string.Empty;
			storeResult = null;
		}
		
		public override void OnEnter() {
			if ((questName == null) || (string.IsNullOrEmpty(questName.Value))) {
				LogError(string.Format("{0}: Quest Name is null or blank.", DialogueDebug.Prefix));
			} else {
				QuestState questState = QuestLog.GetQuestState(questName.Value);
				if (storeResult != null) storeResult.Value = questState.ToString().ToLower();
				switch (questState) {
				case QuestState.Unassigned: Fsm.Event(unassignedStateEvent); break;
				case QuestState.Active: Fsm.Event(activeStateEvent); break;
				case QuestState.Success: Fsm.Event(successStateEvent); break;
				case QuestState.Failure: Fsm.Event(failureStateEvent); break;
				}
			}
			Finish();
		}
		
	}
	
}