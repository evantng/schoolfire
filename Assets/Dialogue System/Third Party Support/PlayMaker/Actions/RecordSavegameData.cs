using System;
using UnityEngine;
using HutongGames.PlayMaker;

namespace PixelCrushers.DialogueSystem.PlayMaker {
	
	[ActionCategory("Dialogue System")]
	[Tooltip("Stores savegame data in a string variable.")]
	public class RecordSavegameData : FsmStateAction {
		
		[RequiredField]
		[UIHint(UIHint.Variable)]
		[Tooltip("Store the result in a String variable")]
		public FsmString storeResult;
		
		public override void Reset() {
			storeResult = null;
		}
		
		public override void OnEnter() {
			if (storeResult != null) storeResult.Value = PersistentDataManager.GetSaveData();
			Finish();
		}
		
	}
	
}