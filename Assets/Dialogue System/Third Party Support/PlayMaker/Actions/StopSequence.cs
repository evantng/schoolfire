using System;
using UnityEngine;
using HutongGames.PlayMaker;

namespace PixelCrushers.DialogueSystem.PlayMaker {
	
	[ActionCategory("Dialogue System")]
	[Tooltip("Stops a sequence.")]
	public class StopSequence : FsmStateAction {
		
		[RequiredField]
		[UIHint(UIHint.Variable)]
		[Tooltip("The sequencer object stored by a Start Sequence action")]
		public FsmObject sequencerHandle;
		
		public override void Reset() {
			sequencerHandle = null;
		}
		
		public override void OnEnter() {
			Sequencer sequencer = sequencerHandle.Value as Sequencer;
			if (sequencer != null) DialogueManager.StopSequence(sequencer);
			Finish();
		}
		
	}
	
}