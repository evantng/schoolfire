using System;
using UnityEngine;
using HutongGames.PlayMaker;

namespace PixelCrushers.DialogueSystem.PlayMaker {
	
	[ActionCategory("Dialogue System")]
	[Tooltip("Starts a cutscene sequence.")]
	public class StartSequence : FsmStateAction {
		
		[RequiredField]
		[Tooltip("The sequence to play")]
		public FsmString sequence;
		
		[Tooltip("The speaker, if the sequence references 'speaker' (optional)")]
		public FsmGameObject speaker;
		
		[Tooltip("The listener (optional)")]
		public FsmGameObject listener;
		
		[Tooltip("Tick to send 'OnSequenceStart' and 'OnSequenceEnd' messages to the participants")]
		public FsmBool informParticipants;
		
		[UIHint(UIHint.Variable)]
		[Tooltip("Store the resulting sequence handler in an Object variable")]
		public FsmObject storeResult;
		
		public override void Reset() {
			if (sequence != null) sequence.Value = string.Empty;
			if (speaker != null) speaker.Value = null;
			if (listener != null) listener.Value = null;
			if (informParticipants != null) informParticipants.Value = false;
			storeResult = null;
		}
		
		public override void OnEnter() {
			Transform speakerTransform = (speaker.Value != null) ? speaker.Value.transform : null;
			Transform listenerTransform = (listener.Value != null) ? listener.Value.transform : null;
			storeResult = DialogueManager.PlaySequence(sequence.Value, speakerTransform, listenerTransform, informParticipants.Value);
			Finish();
		}
		
	}
	
}