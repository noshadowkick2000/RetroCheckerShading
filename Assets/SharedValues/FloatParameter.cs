using UnityEngine;

namespace SharedValues
{
    [CreateAssetMenu(fileName = "Data", menuName = "SharedValues", order = 1)]
    public class FloatParameter : ScriptableObject
    {
        public float value;
    }
}
