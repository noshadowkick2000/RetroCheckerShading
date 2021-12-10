using Root.General;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "SharedValues", order = 2)]
public class PlatformerAttributes : ScriptableObject
{
    public float movementSpeed;
    public float accelerationSpeed;
    public float turnSpeed;
}
