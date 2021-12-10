using UnityEngine;

namespace Root.MainMenu.Scripts
{
  [RequireComponent(typeof(LineRenderer))]
  public class LineAnchor : MonoBehaviour
  {
    [SerializeField] private Transform connectedPoint;
    private LineRenderer lr;

    private void Awake()
    {
      lr = GetComponent<LineRenderer>();
    }

    private void Update()
    {
      Vector3[] positions = new[] {transform.position, connectedPoint.position};
      lr.SetPositions(positions);
    }
  }
}
