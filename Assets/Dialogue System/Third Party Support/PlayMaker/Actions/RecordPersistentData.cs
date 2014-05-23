using System;
using UnityEngine;
using HutongGames.PlayMaker;

namespace PixelCrushers.DialogueSystem.PlayMaker {
	
	[ActionCategory("Dialogue System")]
	[Tooltip("Records persistent data. Use to save the state of the current level before changing to a new level.")]
	public class RecordPersistentData : FsmStateAction {
		
		public override void OnEnter() {
			PersistentDataManager.Record();
			Finish();
		}
		
	}
	
}