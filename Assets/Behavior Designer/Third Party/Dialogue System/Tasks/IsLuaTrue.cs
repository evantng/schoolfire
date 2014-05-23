using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using PixelCrushers.DialogueSystem;

namespace BehaviorDesigner.Runtime.Tasks.DialugeSystem
{
    [TaskDescription("Returns if the Lua code is true.")]
    [TaskCategory("Dialogue System")]
    [HelpURL("http://www.opsive.com/assets/BehaviorDesigner/documentation.php?id=57")]
    [TaskIcon("DialogueSystemIcon.png")]
    public class IsLuaTrue : Conditional
    {
        [Tooltip("The Lua code to run")]
        public SharedString luaCode;

        public override TaskStatus OnUpdate()
        {
            if (luaCode == null || string.IsNullOrEmpty(luaCode.Value)) {
                Debug.LogWarning("IsLuaTrue Task: Lua code is null or empty.");
                return TaskStatus.Failure;
            }

            return Lua.IsTrue(luaCode.Value) ? TaskStatus.Success : TaskStatus.Failure;
        }

        public override void OnReset()
        {
            if (luaCode != null)
                luaCode.Value = "";
        }
    }
}