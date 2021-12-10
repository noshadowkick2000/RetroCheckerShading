using UnityEngine;

namespace Root.MainMenu.Scripts.Connectors
{
    public class CartridgeConnector : Connector
    {
        [SerializeField] private int sceneIndex;

        private void Start()
        {
            connectorCommands = CommandList.Scene + " " + sceneIndex.ToString();
        }
    }
}
