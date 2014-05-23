using UnityEngine;
using UnityEditor;
using System.IO;
using System.Collections.Generic;
using PixelCrushers.DialogueSystem.BehaviorDesigner;

namespace PixelCrushers.DialogueSystem.Editors {
	
	/// <summary>
	/// This class defines the Behavior Designer integration menu items in the Dialogue System menu.
	/// </summary>
	static public class BehaviorDesignerMenuItems {

		[MenuItem("Window/Dialogue System/Component/Integration/Behavior Designer/Behavior Tree Lua Bridge", false, 551)]
		public static void AddComponentBehaviorTreeLuaBridge() {
			DialogueSystemMenuItems.AddComponentToSelection<BehaviorTreeLuaBridge>();
		}
		
	}
		
}
