using System;
using UnityEngine;
using HutongGames.PlayMaker;

namespace PixelCrushers.DialogueSystem.PlayMaker {
	
	[ActionCategory("Dialogue System")]
	[Tooltip("Adds a new entry to a quest.")]
	public class AddQuestEntry : FsmStateAction {
		
		[RequiredField]
		[Tooltip("The name of the quest")]
		public FsmString questName;
		
		[RequiredField]
		[Tooltip("The quest entry description")]
		public FsmString description;
		
		public override void Reset() {
			if (questName != null) questName.Value = string.Empty;
			if (description != null) description.Value = string.Empty;
		}
		
		public override void OnEnter() {
			QuestLog.AddQuestEntry(questName.Value, description.Value);
			Finish();
		}
		
	}
	
}