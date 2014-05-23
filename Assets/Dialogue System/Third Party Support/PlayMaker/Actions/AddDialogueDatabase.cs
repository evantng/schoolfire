using System;
using UnityEngine;
using HutongGames.PlayMaker;

namespace PixelCrushers.DialogueSystem.PlayMaker {
	
	[ActionCategory("Dialogue System")]
	[Tooltip("Adds a dialogue database to the Dialogue Manager's master database.")]
	public class AddDialogueDatabase : FsmStateAction {
		
		[RequiredField]
		[Tooltip("The dialogue database to add")]
		public DialogueDatabase database;
		
		public override void Reset() {
			database = null;
		}
		
		public override void OnEnter() {
			DialogueManager.AddDatabase(database);
			Finish();
		}
		
	}
	
}