using System;
using UnityEngine;
using HutongGames.PlayMaker;

namespace PixelCrushers.DialogueSystem.PlayMaker {

	public static class PlayMakerTools {

		public static bool IsValueAssigned(FsmString fsmString) {
			return (fsmString != null) && !fsmString.IsNone && !string.IsNullOrEmpty(fsmString.Value);
		}

		public static bool IsValueAssigned(FsmInt fsmInt) {
			return (fsmInt != null) && !fsmInt.IsNone;
		}
		
		public static string LuaTableName(LuaTableEnum table) {
			switch (table) {
			case LuaTableEnum.ActorTable: return "Actor";
			case LuaTableEnum.ItemTable: return "Item";
			case LuaTableEnum.LocationTable: return "Location";
			default: return null;
			}
		}

	}
	
}