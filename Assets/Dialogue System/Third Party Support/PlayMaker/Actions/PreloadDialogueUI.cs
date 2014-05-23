using System;
using UnityEngine;
using HutongGames.PlayMaker;

namespace PixelCrushers.DialogueSystem.PlayMaker {
	
	[ActionCategory("Dialogue System")]
	[Tooltip("Preloads the Dialogue Manager's dialogue UI, which is normally loaded just before the first conversation/bark/alert.")]
	public class PreloadDialogueUI : FsmStateAction {
		
		public override void OnEnter() {
			IDialogueUI ui = DialogueManager.DialogueUI;
			if ((ui == null) && DialogueDebug.LogWarnings) Debug.LogWarning(string.Format("{0}: Unable to load the dialogue UI.", DialogueDebug.Prefix));
			Finish();
		}
		
	}
	
}