using System;
using UnityEngine;
using HutongGames.PlayMaker;

namespace PixelCrushers.DialogueSystem.PlayMaker {
	
	[ActionCategory("Dialogue System")]
	[Tooltip("Sets a dialogue database to be the Dialogue Manager's default database.")]
	public class SetDefaultDialogueDatabase : FsmStateAction {
		
		[RequiredField]
		[Tooltip("The new default dialogue database")]
		public DialogueDatabase database;
		
		public override void Reset() {
			database = null;
		}
		
		public override void OnEnter() {
			DialogueManager.Instance.initialDatabase = database;
			Finish();
		}
		
	}
	
}