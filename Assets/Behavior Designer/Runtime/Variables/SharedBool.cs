using UnityEngine;
using System.Collections;

namespace BehaviorDesigner.Runtime
{
    [System.Serializable]
    public class SharedBool : SharedVariable
    {
        public bool Value { get { return mValue; } set { mValue = value; } }
        [SerializeField]
        private bool mValue;

        public SharedBool() { mValueType = SharedVariableTypes.Bool; }

        public override object GetValue() { return mValue; }
        public override void SetValue(object value) { mValue = (bool)value; }

        public override string ToString() { return mValue.ToString(); }
    }
}