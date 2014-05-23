using System;
using UnityEngine;
using HutongGames.PlayMaker;

namespace PixelCrushers.DialogueSystem.PlayMaker {
	
	[ActionCategory("Dialogue System")]
	[Tooltip("Checks whether a sequencer is playing a sequence.")]
	public class IsSequencePlaying : FsmStateAction {
		
		[RequiredField]
		[UIHint(UIHint.Variable)]
		[Tooltip("The sequencer object stored by a Start Sequence action")]
		public FsmObject sequencerHandle;
		
		[UIHint(UIHint.Variable)]
		[Tooltip("Store the result in a Bool variable")]
		public FsmBool storeResult;
		
		[Tooltip("Repeat every frame while the state is active")]
		public FsmBool everyFrame;

		public FsmEvent playingEvent;
		public FsmEvent notPlayingEvent;
		
		public override void Reset() {
			if (sequencerHandle != null) sequencerHandle.Value = null;
			if (storeResult != null) storeResult.Value = false;
			if (everyFrame != null) everyFrame.Value = false;
		}
		
		public override void OnEnter() {
			CheckSequencer();
			if ((everyFrame == null) || (everyFrame.Value == false)) Finish();
		}
		
		public override void OnUpdate() {
			if (everyFrame != null) {
				if (everyFrame.Value == true) {
					CheckSequencer();
				} else {
					Finish();
				}
			}
		}
		
		private void CheckSequencer() {
			Sequencer sequencer = sequencerHandle.Value as Sequencer;
			bool isPlaying = sequencer.IsPlaying;
			if ((sequencer != null) && (everyFrame != null)) everyFrame.Value = isPlaying;
			if (isPlaying) {
				Fsm.Event(playingEvent);
			} else {
				Fsm.Event(notPlayingEvent);
			}
		}
		
	}
	
}