using UnityEngine;
using System.Collections;

namespace BehaviorDesigner.Runtime
{
    [System.Serializable]
    public class SharedString : SharedVariable
    {
        public string Value { get { return mValue; } set { mValue = value; } }
        [SerializeField]
        private string mValue;

        public SharedString() { mValueType = SharedVariableTypes.String; }

        public override object GetValue() { return mValue; }
        public override void SetValue(object value) { mValue = (string)value; }

        public override string ToString() { return string.IsNullOrEmpty(mValue) ? "" : mValue.ToString(); }
    }
}