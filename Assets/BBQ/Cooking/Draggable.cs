using JetBrains.Annotations;
using MainMenu;
using SharedValues;
using UnityEngine;

namespace BBQ.Cooking
{
    [RequireComponent(typeof(Rigidbody))]
    public class Draggable : MonoBehaviour
    {
        private Camera mainCamera;

        [SerializeField] private FloatParameter offset;
        [SerializeField] private FloatParameter lerpFactor;

        private Rigidbody rb;
        private Collider cl;

        private bool dragging;

        private ConnectorHub[] connectorHubs;

        private ConnectorHub closestHub;

        public delegate void BreakFree();

        private void Awake()
        {
            rb = GetComponent<Rigidbody>();
            cl = GetComponent<Collider>();

            mainCamera = Camera.main;
        }

        private void OnMouseDown()
        {
            dragging = true;
            rb.isKinematic = true;
            cl.enabled = false;
            MoveConnector();

            grill?.SimulateOnTriggerExit(GetComponent<Collider>());
        }

        [CanBeNull] private Grill grill;

        public void HookGrill(Grill newGrill)
        {
            grill = newGrill;
        }

        public void UnHookGrill()
        {
            grill = null;
        }

        private void MoveConnector()
        {
            // Cast physics raycast to surface of mouse direction
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

            if (!Physics.Raycast(ray, out RaycastHit hit)) return;
            if (hit.transform == transform) return;

            Vector3 target = hit.point + hit.normal * offset.value;
            transform.position = Vector3.Slerp(transform.position, target, lerpFactor.value);
            Quaternion directionRot = Quaternion.Euler(0, mainCamera.transform.rotation.eulerAngles.y, 0);
            transform.rotation = Quaternion.Lerp(transform.rotation,
                Quaternion.LookRotation(directionRot * Vector3.back, hit.normal), lerpFactor.value);
        }

        private void Update()
        {
            if (Input.GetMouseButtonUp(0) && dragging)
            {
                MouseReleased();
            }
            else if (!dragging) return;

            MoveConnector();
        }

        private void MouseReleased()
        {
            dragging = false;
            cl.enabled = true;

            rb.isKinematic = false;
        }
    }
}