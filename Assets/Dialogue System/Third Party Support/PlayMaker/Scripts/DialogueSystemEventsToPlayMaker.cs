using System;
using UnityEngine;
using HutongGames.PlayMaker;

namespace PixelCrushers.DialogueSystem.PlayMaker {

	/// <summary>
	/// This component sends Dialogue System events to PlayMaker FSMs. Generally you will add this
	/// component to the Dialogue Manager or an actor such as the player object. See the user manual
	/// section Script Overview > Notification Messages for information about Dialogue System events.
	/// </summary>
	public class DialogueSystemEventsToPlayMaker : MonoBehaviour {

		/// <summary>
		/// The FSMs that will receive Dialogue System events.
		/// </summary>
		public PlayMakerFSM[] FSMs;

		/// <summary>
		/// Sends an event to the FSMs.
		/// </summary>
		/// <param name="fsmEventName">FSM event name.</param>
		public void SendEvent(string fsmEventName) {
			if (FSMs != null) {
				foreach (var behavior in FSMs) {
					behavior.Fsm.Event(fsmEventName);
				}
			}
		}

		/// <summary>
		/// Sent at the start of a conversation. The actor is the other participant in the conversation. 
		/// This message is also broadcast to the Dialogue Manager object and its children.
		/// Fsm.EventData.GameObjectData is set to the actor.
		/// </summary>
		/// <param name="actor">The other participant in the conversation.</param>
		void OnConversationStart(Transform actor) {
			Fsm.EventData.GameObjectData = (actor != null) ? actor.gameObject : null;
			SendEvent("OnConversationStart");
		}

		/// <summary>
		/// Sent at the end of a conversation. The actor is the other participant in the conversation. 
		/// This message is also broadcast to the Dialogue Manager object and its children after the 
		/// dialogue UI has closed.
		/// Fsm.EventData.GameObjectData is set to the actor.
		/// </summary>
		/// <param name="actor">Actor.</param>
		void OnConversationEnd(Transform actor) {
			Fsm.EventData.GameObjectData = (actor != null) ? actor.gameObject : null;
			SendEvent("OnConversationEnd");
		}

		/// <summary>
		/// Broadcast to the Dialogue Manager object (not the participants) if a conversation ended because 
		/// the player presses the cancel key or button during the player response menu.
		/// Fsm.EventData.GameObjectData is set to the actor.
		/// </summary>
		/// <param name="actor">Actor.</param>
		void OnConversationCancelled(Transform actor) {
			Fsm.EventData.GameObjectData = (actor != null) ? actor.gameObject : null;
			SendEvent("OnConversationCancelled");
		}

		/// <summary>
		/// Sent whenever a line is spoken. See the PixelCrushers.DialogueSystem.Subtitle reference.
		/// </summary>
		/// <param name="subtitle">Subtitle.</param>
		void OnConversationLine(Subtitle subtitle) {
			SendEvent("OnConversationLine");
		}

		/// <summary>
		/// Broadcast to the Dialogue Manager object (not the participants) if the player presses the 
		/// cancel key or button while a line is being delivered. Cancelling causes the Dialogue System to 
		/// jump to the end of the line and continue to the next line or response menu.
		/// </summary>
		/// <param name="subtitle">Subtitle.</param>
		void OnConversationLineCancelled(Subtitle subtitle) {
			SendEvent("OnConversationLineCancelled");
		}

		/// <summary>
		/// Sent to the Dialogue Manager object (not the participants) if the response menu times out. 
		/// The DialogueSystemController script handles timeouts according to its display settings. You 
		/// can add your own scripts to the Dialogue Manager object that also listens for this message.
		/// </summary>
		void OnConversationTimeout() {
			SendEvent("OnConversationTimeout");
		}

		/// <summary>
		/// Sent at the start of a bark. The actor is the other participant.
		/// Fsm.EventData.GameObjectData is set to the actor.
		/// </summary>
		/// <param name="actor">Actor.</param>
		void OnBarkStart(Transform actor) {
			Fsm.EventData.GameObjectData = (actor != null) ? actor.gameObject : null;
			SendEvent("OnBarkStart");
		}

		/// <summary>
		/// Sent at the end of a bark. The actor is the other participant.
		/// Fsm.EventData.GameObjectData is set to the actor.
		/// </summary>
		/// <param name="actor">Actor.</param>
		void OnBarkEnd(Transform actor) {
			Fsm.EventData.GameObjectData = (actor != null) ? actor.gameObject : null;
			SendEvent("OnBarkEnd");
		}

		/// <summary>
		/// Sent at the beginning of a cutscene sequence. The actor is the other participant. 
		/// (Sequences can have an optional speaker and listener.)
		/// Fsm.EventData.GameObjectData is set to the actor.
		/// </summary>
		/// <param name="actor">Actor.</param>
		void OnSequenceStart(Transform actor) {
			Fsm.EventData.GameObjectData = (actor != null) ? actor.gameObject : null;
			SendEvent("OnSequenceStart");
		}

		/// <summary>
		/// Sent at the end of a sequence. The actor is the other participant.
		/// Fsm.EventData.GameObjectData is set to the actor.
		/// </summary>
		/// <param name="actor">Actor.</param>
		void OnSequenceEnd(Transform actor) {
			Fsm.EventData.GameObjectData = (actor != null) ? actor.gameObject : null;
			SendEvent("OnSequenceEnd");
		}

	}

}