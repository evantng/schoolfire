using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

namespace BehaviorDesigner.Samples
{
    [TaskIcon("ExternalBehaviorTreeIcon.png")]
    [TaskCategory("RTS")]
    public class AttackBehaviorTreeReference : BehaviorTreeReference
    {
        [InheritedField]
        public SharedTransform target;
    }
}