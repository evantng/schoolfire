using UnityEngine;
using System.Collections;
using PixelCrushers.DialogueSystem;
using PixelCrushers.DialogueSystem.SequencerCommands;
using BehaviorDesigner.Runtime;

namespace PixelCrushers.DialogueSystem.BehaviorDesigner {

	/// <summary>
	/// Implements the Behavior Designer sequencer command BehaviorVariable(subject, variableName, value).
	/// - <em>subject</em>: The name of a GameObject containing a behavior tree, or <c>speaker<c> or <c>listener</c>.
	/// The behavior tree can be located on a child object.
	/// - <em>variableName</em>: The name of a shared variable on the behavior tree. These
	/// variable types are supported: Bool, Float, Int, String, GameObject, Object, Transform, Vector3.
	/// - <em>value</em>: The new value of the variable.
	/// </summary>
	public class SequencerCommandBehaviorVariable : SequencerCommand {

		public void Start() {
			Transform subject = GetSubject(0);
			string variableName = GetParameter(1);
			string value = GetParameter(2);
			if (subject == null) {
				if (DialogueDebug.LogWarnings) Debug.LogWarning(string.Format("{0}: Sequencer: BehaviorVariable({1}, {2}, {3}) subject is null", DialogueDebug.Prefix, GetParameter(0), variableName, value));
			} else {
				Behavior behavior = subject.GetComponentInChildren<Behavior>();
				if (behavior == null) {
					if (DialogueDebug.LogWarnings) Debug.LogWarning(string.Format("{0}: Sequencer: BehaviorVariable({1}, {2}, {3}): {1} does not have a Behavior[Tree] component", DialogueDebug.Prefix, GetParameter(0), variableName, value));
				} else {
					if (DialogueDebug.LogInfo) Debug.Log(string.Format("{0}: Sequencer: BehaviorVariable({1}, {2}, {3})", DialogueDebug.Prefix, GetParameter(0), variableName, value));
					var variable = behavior.GetVariable(variableName);
					if (variable == null) {
						if (DialogueDebug.LogWarnings) Debug.LogWarning(string.Format("{0}: Sequencer: BehaviorVariable({1}, {2}, {3}): variable '{2}' not found on {1}", DialogueDebug.Prefix, GetParameter(0), variableName, value));
					} else if (variable is SharedBool) {
						(variable as SharedBool).Value = string.Equals(value, "true", System.StringComparison.OrdinalIgnoreCase);
					} else if (variable is SharedFloat) {
						(variable as SharedFloat).Value = Tools.StringToFloat(value);
					} else if (variable is SharedInt) {
						(variable as SharedInt).Value = Tools.StringToInt(value);
					} else if (variable is SharedString) {
						(variable as SharedString).Value = value;
					} else if (variable is SharedGameObject) {
						Transform t = GetNamedTransform(value);
						if (t != null) (variable as SharedGameObject).Value = t.gameObject;
					} else if (variable is SharedObject) {
						Transform t = GetNamedTransform(value);
						if (t != null) (variable as SharedObject).Value = t.gameObject;
					} else if (variable is SharedTransform) {
						Transform t = GetNamedTransform(value);
						if (t != null) (variable as SharedTransform).Value = t;
					} else if (variable is SharedVector3) {
						Transform t = GetNamedTransform(value);
						if (t != null) (variable as SharedVector3).Value = t.position;
					} else {
						if (DialogueDebug.LogWarnings) Debug.LogWarning(string.Format("{0}: Sequencer: BehaviorVariable({1}, {2}, {3}): does not support variables of type '{4}'", 
						                                                              DialogueDebug.Prefix, GetParameter(0), variableName, value, variable.GetType().Name));
					}
				}
			}
			Stop();
		}

		private Transform GetNamedTransform(string value) {
			Transform t = SequencerTools.GetSubject(value, Sequencer.Speaker, Sequencer.Listener);
			if (t == null && DialogueDebug.LogWarnings) Debug.LogWarning(string.Format("{0}: Sequencer: BehaviorVariable({1}, {2}, {3}): couldn't find '{3}'", DialogueDebug.Prefix, GetParameter(0), GetParameter(1), GetParameter(2)));
			return t;
		}
		
	}
	 
}