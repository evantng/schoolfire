using System;
using UnityEngine;
using HutongGames.PlayMaker;

namespace PixelCrushers.DialogueSystem.PlayMaker {
	
	[ActionCategory("Dialogue System")]
	[Tooltip("Gets the state of a quest entry in a quest.")]
	public class GetQuestEntryState : FsmStateAction {
		
		[RequiredField]
		[Tooltip("The name of the quest")]
		public FsmString questName;
		
		[RequiredField]
		[Tooltip("The quest entry number (from 1)")]
		public FsmInt entryNumber;
		
		[UIHint(UIHint.Variable)]
		[Tooltip("Store the result in a String variable ('unassigned', 'active', 'success', or 'failure')")]
		public FsmString storeResult;

		public FsmEvent unassignedStateEvent;
		public FsmEvent activeStateEvent;
		public FsmEvent successStateEvent;
		public FsmEvent failureStateEvent;
		
		public override void Reset() {
			if (questName != null) questName.Value = string.Empty;
			if (entryNumber != null) entryNumber.Value = 0;
			storeResult = null;
		}
		
		public override void OnEnter() {
			if (PlayMakerTools.IsValueAssigned(questName) && PlayMakerTools.IsValueAssigned(entryNumber)) {
				QuestState questState = QuestLog.GetQuestEntryState(questName.Value, Mathf.Max (1, entryNumber.Value));
				if (storeResult != null) storeResult.Value = questState.ToString().ToLower();
				switch (questState) {
				case QuestState.Unassigned: Fsm.Event(unassignedStateEvent); break;
				case QuestState.Active: Fsm.Event(activeStateEvent); break;
				case QuestState.Success: Fsm.Event(successStateEvent); break;
				case QuestState.Failure: Fsm.Event(failureStateEvent); break;
				}
			} else {
				LogError(string.Format("{0}: Quest Name and Entry Number must be assigned first.", DialogueDebug.Prefix));
			}
			Finish();
		}
		
	}
	
}