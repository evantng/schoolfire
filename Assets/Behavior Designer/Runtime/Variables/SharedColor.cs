using UnityEngine;
using System.Collections;

namespace BehaviorDesigner.Runtime
{
    [System.Serializable]
    public class SharedColor : SharedVariable
    {
        public Color Value { get { return mValue; } set { mValue = value; } }
        [SerializeField]
        private Color mValue;

        public SharedColor() { mValueType = SharedVariableTypes.Color; }

        public override object GetValue() { return mValue; }
        public override void SetValue(object value) { mValue = (Color)value; }

        public override string ToString() { return mValue.ToString(); }
    }
}