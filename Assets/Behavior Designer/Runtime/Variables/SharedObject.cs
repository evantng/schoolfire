using UnityEngine;
using System.Collections;

namespace BehaviorDesigner.Runtime
{
    [System.Serializable]
    public class SharedObject : SharedVariable
    {
        public Object Value { get { return mValue; } set { mValue = value; } }
        [SerializeField]
        private Object mValue;

        public SharedObject() { mValueType = SharedVariableTypes.Object; }

        public override object GetValue() { return mValue; }
        public override void SetValue(object value) { mValue = (Object)value; }

        public override string ToString() { return (mValue == null ? "null" : mValue.name); }
    }
}