using UnityEngine;

namespace Rendering
{
    public class Spin : MonoBehaviour
    {
        [SerializeField] private float speed = .1f;

        // Update is called once per frame
        void Update()
        {
            transform.RotateAround(transform.position, Vector3.up, speed);
        }
    }
}
