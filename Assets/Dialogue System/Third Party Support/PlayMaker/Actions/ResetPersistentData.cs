using System;
using UnityEngine;
using HutongGames.PlayMaker;

namespace PixelCrushers.DialogueSystem.PlayMaker {
	
	[ActionCategory("Dialogue System")]
	[Tooltip("Resets persistent data. Use when starting a new game.")]
	public class ResetPersistentData : FsmStateAction {
		
		public override void OnEnter() {
			PersistentDataManager.Reset();
			Finish();
		}
		
	}
	
}