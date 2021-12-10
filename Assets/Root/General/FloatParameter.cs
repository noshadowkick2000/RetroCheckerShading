using UnityEngine;

namespace Root.General
{
    [CreateAssetMenu(fileName = "Data", menuName = "Parameter", order = 1)]
    public class FloatParameter : ScriptableObject
    {
        public float value;
    }
}
