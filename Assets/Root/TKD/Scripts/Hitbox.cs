using System;
using UnityEngine;

namespace Root.TKD.Scripts
{
    public class Hitbox : MonoBehaviour
    {
        private void OnDrawGizmos()
        {
            Quaternion rot = Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0);
            Matrix4x4 rotationMatrix = Matrix4x4.TRS(transform.position,
                rot, transform.lossyScale);
            Gizmos.matrix = rotationMatrix;
            
            Gizmos.DrawWireCube(Vector3.zero, Vector3.one);
        }
    }
}
