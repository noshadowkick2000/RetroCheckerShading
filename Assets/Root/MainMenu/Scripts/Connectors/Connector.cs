using System.Collections;
using Root.General;
using UnityEngine;

namespace Root.MainMenu.Scripts.Connectors
{
  [RequireComponent(typeof(Rigidbody))]
  public class Connector : MonoBehaviour
  {
    public enum ConnectorType
    {
      PlayerOne,
      PlayerTwo,
      PlayerThree,
      PlayerFour
    }

    [Header("Only use for debugging, otherwise keep empty")]
    [SerializeField] protected string connectorCommands;
    
    private Camera mainCamera;

    [SerializeField] private FloatParameter offset;
    [SerializeField] private FloatParameter lerpFactor;

    [SerializeField] private FloatParameter connectionTime;

    private Rigidbody rb;
    private Collider cl;

    private bool dragging;

    private ConnectorHub[] connectorHubs;

    private ConnectorHub closestHub;
    private bool inRange = false;
    private bool docked;

    private bool Docked
    {
      set
      {
        if (docked && !value)
        {
          // Disconnect
          closestHub.Disconnect();
        }
        else if (!docked && value)
        {
          // Connect
          closestHub.Connect(connectorCommands);
        }
      
        docked = value;
      }
    }

    private void Awake()
    {
      rb = GetComponent<Rigidbody>();
      cl = GetComponent<Collider>();

      mainCamera = Camera.main;

      connectorHubs = FindObjectsOfType<ConnectorHub>();
    }

    private void OnMouseDown()
    {
      StopCoroutine(AnimateConnection());
      Docked = false;
      dragging = true;
      rb.isKinematic = true;
      cl.enabled = false;
      MoveConnector();
    }

    private void MoveConnector()
    {
      // Cast physics raycast to surface of mouse direction
      Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

      if (!Physics.Raycast(ray, out RaycastHit hit)) return;
      if (hit.transform == transform) return;

      Vector3 target = hit.point + hit.normal * offset.value;
      transform.position = Vector3.Slerp(transform.position, target, lerpFactor.value);

      transform.rotation = Quaternion.Lerp(transform.rotation, inRange ? closestHub.transform.rotation : Quaternion.Euler(0, 0, 0), lerpFactor.value);
    }

    private void Update()
    {
      SetClosestHubInRange();
    
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

      if (!inRange || closestHub == null)
        rb.isKinematic = false;
      else
        StartCoroutine(AnimateConnection());
    }

    private void SetClosestHubInRange()
    {
      float closestDistance = 1000;

      foreach (var hub in connectorHubs)
      {
        float distance = Vector3.Distance(transform.position, hub.transform.position);
        if (distance > closestDistance) continue;

        closestHub = hub;
        closestDistance = distance;
      }

      inRange = closestDistance < closestHub.GetConnectorSize();
    }

    private IEnumerator AnimateConnection()
    {
      Vector3 target = closestHub.transform.position;
      float startTime = Time.time;
      float t = 0;

      while (t < 1)
      {
        t = (Time.time - startTime) / connectionTime.value;
        transform.position = Vector3.Slerp(transform.position, target, t);
      
        yield return null;
      }

      Docked = true;
    }
  }
}