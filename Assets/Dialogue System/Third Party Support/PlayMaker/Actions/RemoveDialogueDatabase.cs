using System;
using UnityEngine;
using HutongGames.PlayMaker;

namespace PixelCrushers.DialogueSystem.PlayMaker {
	
	[ActionCategory("Dialogue System")]
	[Tooltip("Removes a loaded dialogue database from the Dialogue Manager's master database.")]
	public class RemoveDialogueDatabase : FsmStateAction {
		
		[RequiredField]
		[Tooltip("The dialogue database to remove")]
		public DialogueDatabase database;
		
		public override void Reset() {
			database = null;
		}
		
		public override void OnEnter() {
			DialogueManager.RemoveDatabase(database);
			Finish();
		}
		
	}
	
}