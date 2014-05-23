using UnityEngine;
using System.Collections;

namespace BehaviorDesigner.Runtime
{
    [System.Serializable]
    public class SharedTransform : SharedVariable
    {
        public Transform Value { get { return mValue; } set { mValue = value; } }
        [SerializeField]
        private Transform mValue;

        public SharedTransform() { mValueType = SharedVariableTypes.Transform; }

        public override object GetValue() { return mValue; }
        public override void SetValue(object value) { mValue = (Transform)value; }

        public override string ToString() { return (mValue == null ? "null" : mValue.name); }
    }
}