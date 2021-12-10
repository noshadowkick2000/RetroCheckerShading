using Root.General;
using UnityEngine;

namespace Root.MainMenu.Scripts.Connectors
{
  public class ConnectorHub : MonoBehaviour
  {
    [SerializeField] private FloatParameter connectorSize; // How far away the connector can be before it connects

    public float GetConnectorSize()
    {
      return connectorSize.value;
    }

    public virtual void Connect(string command)
    {
    }

    public virtual void Disconnect()
    {
    }
  }
}