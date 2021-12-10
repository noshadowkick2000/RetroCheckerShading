using Root.MainMenu.Scripts.Controls;
using UnityEngine;

namespace Root.General
{
    public class ControlledEntity : MonoBehaviour
    {
        protected Controller ConnectedController;

        public void SetConnectedController(Controller controller)
        {
            ConnectedController = controller;
        }
    }
}