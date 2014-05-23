using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using PixelCrushers.DialogueSystem;

namespace BehaviorDesigner.Runtime.Tasks.DialugeSystem
{
    [TaskDescription("Stops a sequence.")]
    [TaskCategory("Dialogue System")]
    [HelpURL("http://www.opsive.com/assets/BehaviorDesigner/documentation.php?id=65")]
    [TaskIcon("DialogueSystemIcon.png")]
    public class StopSequence : Action
    {
        [Tooltip("The sequencer object stored by a Start Sequence task")]
        public SharedObject sequencerHandle;

        public override TaskStatus OnUpdate()
        {
            var sequencer = sequencerHandle.Value as Sequencer;
            if (sequencer != null) {
                DialogueManager.StopSequence(sequencer);
            }
            return TaskStatus.Success;
        }

        public override void OnReset()
        {
            if (sequencerHandle != null)
                sequencerHandle.Value = null;
        }
    }
}