using System;
using UnityEngine;
using HutongGames.PlayMaker;

namespace PixelCrushers.DialogueSystem.PlayMaker {
	
	[ActionCategory("Dialogue System")]
	[Tooltip("Gets the value of a Lua variable from the Variable[] table.")]
	public class GetVariable : FsmStateAction {
		
		[RequiredField]
		[Tooltip("The name of the variable")]
		public FsmString variableName;

		[UIHint(UIHint.Variable)]
		[Tooltip("The value of the variable as a string")]
		public FsmString storeStringResult;
		
		[UIHint(UIHint.Variable)]
		[Tooltip("The value of the variable as a float")]
		public FsmFloat storeFloatResult;
		
		[UIHint(UIHint.Variable)]
		[Tooltip("The value of the variable as a bool")]
		public FsmBool storeBoolResult;
		
		public override void Reset() {
			if (variableName != null) variableName.Value = string.Empty;
			storeStringResult = null;
			storeFloatResult = null;
			storeBoolResult = null;
		}

		public override string ErrorCheck() {
			bool anyResultVariable = (storeStringResult != null) || (storeFloatResult != null) || (storeBoolResult != null);
			return anyResultVariable ? base.ErrorCheck() : "Assign at least one store result variable.";
		}
		
		public override void OnEnter() {
			if ((variableName == null) || string.IsNullOrEmpty(variableName.Value)) {
				LogWarning(string.Format("{0}: Variable Name isn't assigned or is blank.", DialogueDebug.Prefix));
			} else {
				Lua.Result luaResult = DialogueLua.GetVariable(variableName.Value);
				if (storeStringResult != null) storeStringResult.Value = luaResult.AsString;
				if (storeFloatResult != null) storeFloatResult.Value = luaResult.AsFloat;
				if (storeBoolResult != null) storeBoolResult.Value = luaResult.AsBool;
			}
			Finish();
		}
		
	}
	
}