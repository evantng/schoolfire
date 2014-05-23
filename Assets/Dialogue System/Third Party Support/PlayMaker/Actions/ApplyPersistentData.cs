using System;
using UnityEngine;
using HutongGames.PlayMaker;

namespace PixelCrushers.DialogueSystem.PlayMaker {
	
	[ActionCategory("Dialogue System")]
	[Tooltip("Applies previously-recorded persistent data. Use after returning to a level to bring it back to its recorded state.")]
	public class ApplyPersistentData : FsmStateAction {
		
		public override void OnEnter() {
			PersistentDataManager.Apply();
			Finish();
		}
		
	}
	
}