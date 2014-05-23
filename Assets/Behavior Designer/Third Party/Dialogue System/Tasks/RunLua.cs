using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using PixelCrushers.DialogueSystem;

namespace BehaviorDesigner.Runtime.Tasks.DialugeSystem
{
    [TaskDescription("Runs Lua code.")]
    [TaskCategory("Dialogue System")]
    [HelpURL("http://www.opsive.com/assets/BehaviorDesigner/documentation.php?id=60")]
    [TaskIcon("DialogueSystemIcon.png")]
    public class RunLua : Action
    {
        [Tooltip("The Lua code to run")]
        public SharedString luaCode;

        public override TaskStatus OnUpdate()
        {
            if (luaCode == null || string.IsNullOrEmpty(luaCode.Value)) {
                Debug.LogWarning("RunLua Task: Lua code is null or empty");
                return TaskStatus.Failure;
            }

            Lua.Run(luaCode.Value);
            return TaskStatus.Success;
        }

        public override void OnReset()
        {
            if (luaCode != null)
                luaCode.Value = "";
        }
    }
}