using UnityEngine;
using System.Collections;

namespace BehaviorDesigner.Runtime
{
    [System.Serializable]
    public class SharedRect : SharedVariable
    {
        public Rect Value { get { return mValue; } set { mValue = value; } }
        [SerializeField]
        private Rect mValue;

        public SharedRect() { mValueType = SharedVariableTypes.Rect; }

        public override object GetValue() { return mValue; }
        public override void SetValue(object value) { mValue = (Rect)value; }

        public override string ToString() { return mValue.ToString(); }
    }
}