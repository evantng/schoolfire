using System;
using UnityEngine;
using HutongGames.PlayMaker;

namespace PixelCrushers.DialogueSystem.PlayMaker {
	
	[ActionCategory("Dialogue System")]
	[Tooltip("Stops the current conversation.")]
	public class StopConversation : FsmStateAction {
		
		public override void OnEnter() {
			DialogueManager.StopConversation();
			Finish();
		}
		
	}
	
}