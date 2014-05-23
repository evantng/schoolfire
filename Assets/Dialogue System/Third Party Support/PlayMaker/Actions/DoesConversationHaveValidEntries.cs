using System;
using UnityEngine;
using HutongGames.PlayMaker;

namespace PixelCrushers.DialogueSystem.PlayMaker {
	
	[ActionCategory("Dialogue System")]
	[Tooltip("Checks whether a conversation currently has any valid entries branching from the start entry.")]
	public class DoesConversationHaveValidEntries : FsmStateAction {

		[RequiredField]
		[Tooltip("The conversation containing the bark lines")]
		public FsmString conversation;
		
		[Tooltip("The primary participant in the conversation (e.g., the player)")]
		public FsmGameObject actor;
		
		[Tooltip("The other participant in the conversation (e.g., the NPC)")]
		public FsmGameObject conversant;
		
		[UIHint(UIHint.Variable)]
		[Tooltip("Store the result in a Bool variable")]
		public FsmBool storeResult;

		public FsmEvent validEvent;
		public FsmEvent notValidEvent;
		
		public override void Reset() {
			if (conversation != null) conversation.Value = string.Empty;
			if (actor != null) actor.Value = null;
			if (conversant != null) conversant.Value = null;
			if (storeResult != null) storeResult.Value = false;
		}
		
		public override void OnEnter() {
			string conversationTitle = (conversation != null) ? conversation.Value : string.Empty;
			Transform actorTransform = ((actor != null) && (actor.Value != null)) ? actor.Value.transform : null;
			Transform conversantTransform = ((conversant != null) && (conversant.Value != null)) ? conversant.Value.transform : null;
			if (string.IsNullOrEmpty(conversationTitle)) LogWarning(string.Format("{0}: PlayMaker Action Does Conversation Have Valid Entries - conversation title is blank", DialogueDebug.Prefix));
			bool result = DialogueManager.ConversationHasValidEntry(conversationTitle, actorTransform, conversantTransform);
			if (storeResult != null) storeResult.Value = result;
			if (result == true) {
				Fsm.Event(validEvent);
			} else {
				Fsm.Event(notValidEvent);
			}
			Finish();
		}
		
	}
	
}