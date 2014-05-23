using UnityEngine;
using UnityEditor;
using System.IO;
using PixelCrushers.DialogueSystem.Editors;

namespace PixelCrushers.DialogueSystem.PlayMaker {
	
	/// <summary>
	/// This class defines the PlayMaker menu items in the Dialogue System menu.
	/// </summary>
	static public class PlayMakerMenuItems {
		
		[MenuItem("Window/Dialogue System/Component/PlayMaker/Dialogue System Events", false, 180)]
		public static void AddComponentDialogueSystemEventsToPlayMaker() {
			DialogueSystemMenuItems.AddComponentToSelection<DialogueSystemEventsToPlayMaker>();
		}
		
	}
		
}
