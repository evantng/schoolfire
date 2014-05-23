using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

namespace BehaviorDesigner.Runtime.Tasks.Basic.UnityGameObject
{
    [TaskCategory("Basic/GameObject")]
    [TaskDescription("Returns the component of Type type if the game object has one attached, null if it doesn't. Returns Success.")]
    public class GetComponent : Action
    {
        [Tooltip("The type of component")]
        public SharedString type;
        [Tooltip("The component")]
        public SharedObject storeValue;

        public override TaskStatus OnUpdate()
        {
            storeValue.Value = gameObject.GetComponent(type.Value);

            return TaskStatus.Success;
        }

        public override void OnReset()
        {
            if (type != null) {
                type.Value = "";
            }
            if (storeValue != null) {
                storeValue.Value = null;
            }
        }
    }
}