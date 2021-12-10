using UnityEngine;

namespace Demo
{
    public class SimpleMove : MonoBehaviour
    {
        [SerializeField] private float movementSpeed;
        [SerializeField] private float rotationSpeed;
    
        // Update is called once per frame
        void Update()
        {
            Vector3 movement = Vector3.zero;

            if (Input.GetKey(KeyCode.W))
            {
                movement += Vector3.forward;
            }
            else if (Input.GetKey(KeyCode.S))
            {
                movement += Vector3.back;
            }

            if (Input.GetKey(KeyCode.A))
            {
                transform.Rotate(Vector3.up, -rotationSpeed);
            }
            else if (Input.GetKey(KeyCode.D))
            {
                transform.Rotate(Vector3.up, rotationSpeed);
            }

            transform.position += transform.rotation * (movement.normalized * movementSpeed);
        }
    }
}
