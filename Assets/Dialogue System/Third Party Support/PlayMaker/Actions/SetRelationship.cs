using System;
using UnityEngine;
using HutongGames.PlayMaker;

namespace PixelCrushers.DialogueSystem.PlayMaker {
	
	[ActionCategory("Dialogue System")]
	[Tooltip("Sets a relationship value between two actors.")]
	public class SetRelationship : FsmStateAction {
		
		[RequiredField]
		[Tooltip("The name of actor1 in the Actor[] table")]
		public FsmString actor1Name;
		
		[RequiredField]
		[Tooltip("The name of actor2 in the Actor[] table")]
		public FsmString actor2Name;
		
		[RequiredField]
		[Tooltip("The relationship type")]
		public FsmString relationshipType;
		
		[RequiredField]
		[Tooltip("The relationship value")]
		public FsmFloat relationshipValue;
		
		public override void Reset() {
			if (actor1Name != null) actor1Name.Value = string.Empty;
			if (actor2Name != null) actor2Name.Value = string.Empty;
			if (relationshipType != null) relationshipType.Value = string.Empty;
			if (relationshipValue != null) relationshipValue.Value = 0;
		}
		
		public override void OnEnter() {
			if ((actor1Name != null) && (actor2Name != null) && (relationshipType != null) && (relationshipValue != null)) {
				try {
					Lua.Run(string.Format("SetRelationship(Actor[\"{0}\"], Actor[\"{1}\"], {2}, {3})", 
						DialogueLua.StringToTableIndex(actor1Name.Value), DialogueLua.StringToTableIndex(actor2Name.Value),
						relationshipType.Value, relationshipValue.Value), DialogueDebug.LogInfo);
				} catch (System.NullReferenceException) {
				}
			}
			Finish();
		}
		
	}
	
}