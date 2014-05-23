using System;
using UnityEngine;
using HutongGames.PlayMaker;

namespace PixelCrushers.DialogueSystem.PlayMaker {
	
	[ActionCategory("Dialogue System")]
	[Tooltip("Sets a status value between two assets in the dialogue database.")]
	public class SetStatus : FsmStateAction {
		
		[RequiredField]
		[Tooltip("The full reference to asset1 (e.g., Actor[\"Player\"])")]
		public FsmString asset1;
		
		[RequiredField]
		[Tooltip("The full reference to asset2 (e.g., Item[\"Sword\"]")]
		public FsmString asset2;
		
		[RequiredField]
		[Tooltip("The status value")]
		public FsmString statusValue;
		
		public override void Reset() {
			if (asset1 != null) asset1.Value = string.Empty;
			if (asset2 != null) asset2.Value = string.Empty;
			if (statusValue != null) statusValue.Value = string.Empty;
		}
		
		public override void OnEnter() {
			if ((asset1 != null) && (asset2 != null) && (statusValue != null)) {
				try {
					Lua.Run(string.Format("SetStatus({0}, {1}, \"{2}\")", 
						DialogueLua.SpacesToUnderscores(DialogueLua.DoubleQuotesToSingle(asset1.Value)),
						DialogueLua.SpacesToUnderscores(DialogueLua.DoubleQuotesToSingle(asset2.Value)), 
						DialogueLua.DoubleQuotesToSingle(statusValue.Value)), DialogueDebug.LogInfo);
				} catch (System.NullReferenceException) {
				}
			}
			Finish();
		}
		
	}
	
}