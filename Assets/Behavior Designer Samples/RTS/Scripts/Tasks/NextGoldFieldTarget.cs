using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

namespace BehaviorDesigner.Samples
{
    [TaskCategory("RTS")]
    [TaskDescription("Set the shared variable to the next gold field transform available")]
    public class NextGoldFieldTarget : Action
    {
        [Tooltip("Returned transform of the next target")]
        public SharedTransform target;
        private GoldFieldManager goldFieldManager;

        public override void OnAwake()
        {
            // cache for quick lookup
            goldFieldManager = GoldFieldManager.instance;
        }

        // will return success after the target has been set
        public override TaskStatus OnUpdate()
        {
            // get the next gold field transform from the gold field manager
            target.Value = goldFieldManager.nextGoldFieldTransform();
            return TaskStatus.Success;
        }
    }
}