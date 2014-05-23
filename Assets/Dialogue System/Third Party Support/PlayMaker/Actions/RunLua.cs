using System;
using UnityEngine;
using HutongGames.PlayMaker;

namespace PixelCrushers.DialogueSystem.PlayMaker {
	
	[ActionCategory("Dialogue System")]
	[Tooltip("Runs Lua code.")]
	public class RunLua : FsmStateAction {
		
		[RequiredField]
		[Tooltip("The Lua code to run")]
		public FsmString luaCode;
		
		[Tooltip("Tick to log Lua debug output to the console")]
		public FsmBool debug;
		
		[UIHint(UIHint.Variable)]
		[Tooltip("Store the result in a variable")]
		public FsmVar storeResult;
		
		public override void Reset() {
			if (luaCode != null) luaCode.Value = string.Empty;
			if (debug != null) debug.Value = false;
			storeResult = null;
		}
		
		public override void OnEnter() {
			string luaCodeString = (luaCode != null) ? luaCode.Value : string.Empty;
			bool debugFlag = (debug != null) ? debug.Value : false;
			Lua.Result luaResult = Lua.Run(luaCodeString, debugFlag);
			if ((storeResult != null) && storeResult.useVariable) {
				switch (storeResult.Type) {
				case VariableType.Bool:
					storeResult.SetValue(luaResult.AsBool);
					break;
				case VariableType.Float:
					storeResult.SetValue(luaResult.AsFloat);
					break;
				case VariableType.Int:
					storeResult.SetValue(luaResult.AsInt);
					break;
				case VariableType.String:
					storeResult.SetValue(luaResult.AsString);
					break;
				default:
					if (DialogueDebug.LogWarnings) Debug.LogWarning(string.Format("{0}: Variable type must be Bool, Float, Int, or String for Lua code '{1}'", DialogueDebug.Prefix, luaCode));
					break;
				}
			}
			Finish();
		}
		
	}
	
}