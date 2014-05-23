using UnityEngine;
using System.Collections;
using PixelCrushers.DialogueSystem;
using PixelCrushers.DialogueSystem.SequencerCommands;
using BehaviorDesigner.Runtime;

namespace PixelCrushers.DialogueSystem.BehaviorDesigner {

	/// <summary>
	/// This script synchronizes a behavior tree's shared variables with the
	/// Dialogue System's Lua environment. Attach it to the GameObject that
	/// contains the behavior tree. Synchronization occurs automatically at
	/// the beginning and end of conversations. You can also synchronize manually
	/// by calling SyncToLua() or SyncFromLua().
	/// 
	/// The Lua variables will have the name <em>gameObjectName_variableName</em>.
	/// All blank spaces and hyphens will be converted to underscores.
	/// For example, say an NPC named Private Hart has a behavior tree with a shared
	/// variable named Angry. The Lua variable will be <c>Variable["Private_Hart_Angry"]</c>.
	/// 
	/// Only bools, floats, ints, and strings are synchronized.
	/// </summary>
	public class BehaviorTreeLuaBridge : MonoBehaviour {

		// The behavior tree on this GameObject:
		private Behavior behavior = null;

		void Awake() {
			behavior = GetComponentInChildren<Behavior>();
		}

		/// <summary>
		/// When a conversation starts, sync to Lua. This makes the behavior
		/// tree data available to conversations in Conditions and User Scripts.
		/// </summary>
		/// <param name="actor">The other actor.</param>
		public void OnConversationStart(Transform actor) {
			SyncToLua();
		}

		/// <summary>
		/// When a conversation ends, sync from Lua back into the behavior
		/// tree. If the conversation has changed any values, the changes
		/// will be reflected in the behavior tree.
		/// </summary>
		/// <param name="actor">The other actor.</param>
		public void OnConversationEnd(Transform actor) {
			SyncFromLua();
		}

		/// <summary>
		/// Syncs the behavior tree's shared variables to the Dialogue System's
		/// Lua environment. 
		/// </summary>
		public void SyncToLua() {
			if (behavior == null) return;
			foreach (SharedVariable variable in behavior.GetBehaviorSource().Variables) {
				if (IsSyncableType(variable.ValueType)) {
					DialogueLua.SetVariable(GetLuaVariableName(variable.name), variable.GetValue());
				}
			}
		}

		/// <summary>
		/// Syncs the Dialogue System's Lua environment back into the behavior tree's 
		/// shared variables.
		/// </summary>
		public void SyncFromLua() {
			if (behavior == null) return;
			foreach (SharedVariable variable in behavior.GetBehaviorSource().Variables) {
				if (IsSyncableType(variable.ValueType)) {
					Lua.Result result = DialogueLua.GetVariable(GetLuaVariableName(variable.name));
					if (result.HasReturnValue) {
						variable.SetValue(CastLuaResult(variable.ValueType, result));
					}
				}
			}
		}

		private bool IsSyncableType(SharedVariableTypes variableType) {
			switch (variableType) {
			case SharedVariableTypes.Bool:
			case SharedVariableTypes.Float:
			case SharedVariableTypes.Int:
			case SharedVariableTypes.String:
				return true;
			default:
				return false;
			}
		}

		private string GetLuaVariableName(string variableName) {
			return string.Format("{0}_{1}", name, variableName);
		}

		private object CastLuaResult(SharedVariableTypes variableType, Lua.Result result) {
			switch (variableType) {
			case SharedVariableTypes.Bool:
				return result.AsBool;
			case SharedVariableTypes.Float:
				return result.AsFloat;
			case SharedVariableTypes.Int:
				return result.AsInt;
			case SharedVariableTypes.String:
				return result.AsString;
			default:
				return null;
			}
		}
		
	}

}