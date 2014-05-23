using UnityEngine;
using System.Collections;
using PixelCrushers.DialogueSystem;
using PixelCrushers.DialogueSystem.SequencerCommands;
using BehaviorDesigner.Runtime;

namespace PixelCrushers.DialogueSystem.BehaviorDesigner {
	
	/// <summary>
	/// Implements the Behavior Designer sequencer command Behavior(subject, start|stop|pause|resume).
	/// - <em>subject</em>: The name of a GameObject containing a behavior tree, or <c>speaker<c> or <c>listener</c>.
	/// The behavior tree can be located on a child object.
	/// - <c>start|stop|pause|resume</c>: Control action for the behavior tree. 
	/// 	- <c>start</c>: Starts or restarts the behavior tree.
	/// 	- <c>stop</c>: Stops the behavior tree.
	/// 	- <c>pause</c>: Pauses the behavior tree.
	/// 	- <c>resume</c>: Resumes the behavior tree if paused.
	/// </summary>
	public class SequencerCommandBehavior : SequencerCommand {

		// Translate the control string into an enum to make it easier to work with in code:
		private enum ControlCommand { Start, Stop, Pause, Resume, Undefined }
		
		private ControlCommand GetControlCommand(string s) {
			if (string.Equals("start", s, System.StringComparison.OrdinalIgnoreCase)) {
				return ControlCommand.Start;
			} else if (string.Equals("stop", s, System.StringComparison.OrdinalIgnoreCase)) {
				return ControlCommand.Stop;
			} else if (string.Equals("pause", s, System.StringComparison.OrdinalIgnoreCase)) {
				return ControlCommand.Pause;
			} else if (string.Equals("resume", s, System.StringComparison.OrdinalIgnoreCase)) {
				return ControlCommand.Resume;
			} else {
				return ControlCommand.Undefined;
			}
		}
		
		public void Start() {
			Transform subject = GetSubject(0);
			ControlCommand command = GetControlCommand(GetParameter(1));
			if (subject == null) {
				if (DialogueDebug.LogWarnings) Debug.LogWarning(string.Format("{0}: Sequencer: Behavior({1}, {2}) subject is null", DialogueDebug.Prefix, GetParameter(0), GetParameter(1)));
			} else if (command == ControlCommand.Undefined) {
				if (DialogueDebug.LogWarnings) Debug.LogWarning(string.Format("{0}: Sequencer: Behavior({1}, {2}) command must be 'start', 'stop', or 'resume'", DialogueDebug.Prefix, GetParameter(0), GetParameter(1)));
			} else {
				Behavior behavior = subject.GetComponentInChildren<Behavior>();
				if (behavior == null) {
					if (DialogueDebug.LogWarnings) Debug.LogWarning(string.Format("{0}: Sequencer: Behavior({1}, {2}): {1} does not have a Behavior[Tree] component", DialogueDebug.Prefix, GetParameter(0), GetParameter(1)));
				} else {
					if (DialogueDebug.LogInfo) Debug.Log(string.Format("{0}: Sequencer: Behavior({1}, {2})", DialogueDebug.Prefix, GetParameter(0), GetParameter(1)));
					switch (command) {
					case ControlCommand.Start:
					case ControlCommand.Resume:
						behavior.EnableBehavior();
						break;
					case ControlCommand.Stop:
						behavior.DisableBehavior(false);
						break;
					case ControlCommand.Pause:
						behavior.DisableBehavior(true);
						break;
					}
				}
			}
			Stop();
		}
		
	}
	
}