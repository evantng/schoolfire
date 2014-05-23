using System;
using UnityEngine;
using HutongGames.PlayMaker;

namespace PixelCrushers.DialogueSystem.PlayMaker {
	
	[ActionCategory("Dialogue System")]
	[Tooltip("Starts a conversation.")]
	public class StartConversation : FsmStateAction {
		
		[RequiredField]
		[Tooltip("The conversation to start")]
		public FsmString conversation;
		
		[RequiredField]
		[Tooltip("The primary participant in the conversation (e.g., the player)")]
		public FsmGameObject actor;
		
		[Tooltip("The other participant in the conversation (e.g., the NPC)")]
		public FsmGameObject conversant;
		
		public override void Reset() {
			if (conversation != null) conversation.Value = string.Empty;
			if (actor != null) actor.Value = null;
			if (conversant != null) conversant.Value = null;
		}
		
		public override void OnEnter() {
			string conversationTitle = (conversation != null) ? conversation.Value : string.Empty;
			Transform actorTransform = ((actor != null) && (actor.Value != null)) ? actor.Value.transform : null;
			Transform conversantTransform = ((conversant != null) && (conversant.Value != null)) ? conversant.Value.transform : null;
			if (actorTransform == null) LogWarning(string.Format("{0}: PlayMaker Action Start Conversation - actor is null", DialogueDebug.Prefix));
			if (string.IsNullOrEmpty(conversationTitle)) LogWarning(string.Format("{0}: PlayMaker Action Start Conversation - conversation title is blank", DialogueDebug.Prefix));
			DialogueManager.StartConversation(conversationTitle, actorTransform, conversantTransform);
			Finish();
		}
		
	}
	
}