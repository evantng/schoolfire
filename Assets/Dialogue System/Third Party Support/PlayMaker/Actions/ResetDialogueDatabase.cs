using System;
using UnityEngine;
using HutongGames.PlayMaker;

namespace PixelCrushers.DialogueSystem.PlayMaker {
	
	[ActionCategory("Dialogue System")]
	[Tooltip("Resets the Dialogue Manager's master database.")]
	public class ResetDialogueDatabase : FsmStateAction {
		
		[Tooltip("Tick to reset to the default dialogue database, clear to keep all loaded databases")]
		public FsmBool resetToInitialDatabase;
		
		public override void Reset() {
			if (resetToInitialDatabase != null) resetToInitialDatabase.Value = false;
		}
		
		public override void OnEnter() {	
			DatabaseResetOptions databaseResetOption = resetToInitialDatabase.Value ? DatabaseResetOptions.RevertToDefault : DatabaseResetOptions.KeepAllLoaded;
			DialogueManager.ResetDatabase(databaseResetOption);
			Finish();
		}
		
	}
	
}