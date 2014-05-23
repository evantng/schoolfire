using UnityEngine;
using System.Collections;

namespace BehaviorDesigner.Runtime
{
    [System.Serializable]
    public class SharedVector3 : SharedVariable
    {
        public Vector3 Value { get { return mValue; } set { mValue = value; } }
        [SerializeField]
        private Vector3 mValue;

        public SharedVector3() { mValueType = SharedVariableTypes.Vector3; }

        public override object GetValue() { return mValue; }
        public override void SetValue(object value) { mValue = (Vector3)value; }

        public override string ToString() { return mValue.ToString(); }
    }
}