using UnityEngine;

namespace MainMenu
{
  public class ConnectorHub : MonoBehaviour
  {
    [SerializeField] private float connectorSize; // How far away the connector can be before it connects

    public float GetConnectorSize()
    {
      return connectorSize;
    }

    public virtual void Connect(string command)
    {
    }

    public virtual void Disconnect()
    {
    }
  }
}