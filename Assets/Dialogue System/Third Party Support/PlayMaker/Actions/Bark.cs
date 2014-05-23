using System;
using UnityEngine;
using HutongGames.PlayMaker;

namespace PixelCrushers.DialogueSystem.PlayMaker {
	
	[ActionCategory("Dialogue System")]
	[Tooltip("Makes an NPC bark.")]
	public class Bark : FsmStateAction {
		
		[RequiredField]
		[Tooltip("The conversation containing the bark lines")]
		public FsmString conversation;
		
		[RequiredField]
		[Tooltip("The character speaking the bark")]
		public FsmGameObject speaker;
		
		[Tooltip("The character being barked at (optional)")]
		public FsmGameObject listener;
		
		public override void Reset() {
			if (conversation != null) conversation.Value = string.Empty;
			if (speaker != null) speaker.Value = null;
			if (listener != null) listener.Value = null;
		}
		
		public override void OnEnter() {
			string conversationTitle = (conversation != null) ? conversation.Value : string.Empty;
			Transform speakerTransform = ((speaker != null) && (speaker.Value != null)) ? speaker.Value.transform : null;
			Transform listenerTransform = ((listener != null) && (listener.Value != null)) ? listener.Value.transform : null;
			if (speakerTransform == null) Debug.LogWarning(string.Format("{0}: PlayMaker Action Bark - speaker is null", DialogueDebug.Prefix));
			if (string.IsNullOrEmpty(conversationTitle)) Debug.LogWarning(string.Format("{0}: PlayMaker Action Bark - conversation title is blank", DialogueDebug.Prefix));
			if (listenerTransform != null) {
				DialogueManager.Bark(conversationTitle, speakerTransform, listenerTransform);
			} else {
				DialogueManager.Bark(conversationTitle, speakerTransform);
			}
			Finish();
		}
		
	}
	
}