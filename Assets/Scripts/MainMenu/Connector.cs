using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

  [SerializeField] private Camera mainCamera;

  [SerializeField] private float offset;
  [SerializeField] private float lerpFactor;

  [SerializeField] private float connectionTime;

  private Rigidbody rb;
  private Collider collider;

  private bool dragging;

  private ConnectorHub[] connectorHubs;

  private ConnectorHub closestHub;
  private bool inRange = false;

  private void Awake()
  {
    rb = GetComponent<Rigidbody>();
    collider = GetComponent<Collider>();

    connectorHubs = FindObjectsOfType<ConnectorHub>();
  }

  private void OnMouseDown()
  {
    StopCoroutine(AnimateConnection());
    dragging = true;
    rb.isKinematic = true;
    collider.enabled = false;
    MoveConnector();
  }

  private void MoveConnector()
  {
    // Cast physics raycast to surface of mouse direction
    Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

    if (!Physics.Raycast(ray, out RaycastHit hit)) return;
    if (hit.transform == transform) return;

    Vector3 target = hit.point + hit.normal * offset;
    transform.position = Vector3.Slerp(transform.position, target, lerpFactor);

    transform.rotation = Quaternion.Lerp(transform.rotation, inRange ? closestHub.transform.rotation : Quaternion.Euler(0, 0, 0), lerpFactor);
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
    collider.enabled = true;

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
      t = (Time.time - startTime) / connectionTime;
      transform.position = Vector3.Slerp(transform.position, target, t);
      
      yield return null;
    }
  }
}