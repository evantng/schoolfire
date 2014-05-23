using System;
using UnityEngine;
using HutongGames.PlayMaker;

namespace PixelCrushers.DialogueSystem.PlayMaker {
	
	[ActionCategory("Dialogue System")]
	[Tooltip("Preloads the Dialogue Manager's master database, which is normally loaded just before the first conversation/bark/sequence/quest update.")]
	public class PreloadMasterDatabase : FsmStateAction {
		
		public override void OnEnter() {	
			DialogueManager.PreloadMasterDatabase();
			Finish();
		}
		
	}
	
}