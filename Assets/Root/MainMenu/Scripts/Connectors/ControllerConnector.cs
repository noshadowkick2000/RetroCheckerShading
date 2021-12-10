using UnityEngine;

namespace Root.MainMenu.Scripts.Connectors
{
  public class ControllerConnector : Connector
  {
    [SerializeField] private int controllerIndex;

    private void Start()
    {
      connectorCommands = CommandList.Controller + " " + controllerIndex.ToString();
    }
  }
}
