using System;
using UnityEngine;
using HutongGames.PlayMaker;

namespace PixelCrushers.DialogueSystem.PlayMaker {
	
	[ActionCategory("Dialogue System")]
	[Tooltip("Gets a status value between two assets in the dialogue database.")]
	public class GetStatus : FsmStateAction {
		
		[RequiredField]
		[Tooltip("The full reference to asset1 (e.g., Actor[\"Player\"])")]
		public FsmString asset1;
		
		[RequiredField]
		[Tooltip("The full reference to asset2 (e.g., Item[\"Sword\"]")]
		public FsmString asset2;
		
		[RequiredField]
		[UIHint(UIHint.Variable)]
		[Tooltip("Store the result in a String variable")]
		public FsmString storeResult;
		
		public override void Reset() {
			if (asset1 != null) asset1.Value = string.Empty;
			if (asset2 != null) asset2.Value = string.Empty;
			if (storeResult != null) storeResult.Value = string.Empty;
		}
		
		public override void OnEnter() {
			if ((asset1 != null) && (asset2 != null) && (storeResult != null)) {
				try {
					storeResult.Value = Lua.Run(string.Format("return GetStatus({0}, {1})", 
						DialogueLua.SpacesToUnderscores(DialogueLua.DoubleQuotesToSingle(asset1.Value)), 
						DialogueLua.SpacesToUnderscores(DialogueLua.DoubleQuotesToSingle(asset2.Value))), DialogueDebug.LogInfo).AsString;
				} catch (System.NullReferenceException) {
				}
			}
			Finish();
		}
		
	}
	
}