using System;
using Controls;
using UnityEngine;

namespace MainMenu
{
    public class ControllerConnectorHub : ConnectorHub
    {
        [SerializeField] private ControllerHandler controllerHandler;
        [SerializeField] private int portNumber;

        public override void Connect(string command)
        {
            string[] split = command.Split();
            if (split.Length != 2) return;
            if (split[0] != CommandList.Controller) return;

            controllerHandler.ConnectController(portNumber,  int.Parse(split[1]));
        }

        public override void Disconnect()
        {
            controllerHandler.DisconnectController(portNumber);
        }
    }
}
