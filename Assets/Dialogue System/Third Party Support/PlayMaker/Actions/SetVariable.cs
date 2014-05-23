using System;
using UnityEngine;
using HutongGames.PlayMaker;

namespace PixelCrushers.DialogueSystem.PlayMaker {
	
	[ActionCategory("Dialogue System")]
	[Tooltip("Sets the value of a Lua variable in the Variable[] table.")]
	public class SetVariable : FsmStateAction {
		
		[RequiredField]
		[Tooltip("The name of the variable")]
		public FsmString variableName;

		[Tooltip("The value of the variable as a string")]
		public FsmString stringValue;
		
		[Tooltip("The value of the variable as a float")]
		public FsmFloat floatValue;
		
		[Tooltip("The value of the variable as a bool")]
		public FsmBool boolValue;
		
		public override void Reset() {
			if (variableName != null) variableName.Value = string.Empty;
			stringValue = null;
			floatValue = null;
			boolValue = null;
		}

		public override string ErrorCheck() {
			bool anyValue = (stringValue != null) || (floatValue != null) || (boolValue != null);
			return anyValue ? base.ErrorCheck() : "Assign at least one value field.";
		}
		
		public override void OnEnter() {
			if ((variableName == null) || string.IsNullOrEmpty(variableName.Value)) {
				LogWarning(string.Format("{0}: Variable Name isn't assigned or is blank.", DialogueDebug.Prefix));
			} else {
				if ((stringValue != null) && !stringValue.IsNone) DialogueLua.SetVariable(variableName.Value, stringValue.Value);
				if ((floatValue != null) && !floatValue.IsNone) DialogueLua.SetVariable(variableName.Value, floatValue.Value);
				if ((boolValue != null) && !boolValue.IsNone) DialogueLua.SetVariable(variableName.Value, boolValue.Value);
			}
			Finish();
		}
		
	}
	
}