using UnityEngine;

namespace Rendering
{
    public class Spin : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
            transform.RotateAround(transform.position, Vector3.up, .2f);
        }
    }
}
