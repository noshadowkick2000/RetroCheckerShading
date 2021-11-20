using UnityEngine;

namespace MainMenu
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
