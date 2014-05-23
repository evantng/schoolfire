using UnityEngine;
using System.Collections;

namespace BehaviorDesigner.Runtime
{
    [System.Serializable]
    public class SharedVector4 : SharedVariable
    {
        public Vector4 Value { get { return mValue; } set { mValue = value; } }
        [SerializeField]
        private Vector4 mValue;

        public SharedVector4() { mValueType = SharedVariableTypes.Vector4; }

        public override object GetValue() { return mValue; }
        public override void SetValue(object value) { mValue = (Vector4)value; }

        public override string ToString() { return mValue.ToString(); }
    }
}