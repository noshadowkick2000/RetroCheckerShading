using System;
using Root.MainMenu.Scripts.Controls;
using UnityEngine;

// ReSharper disable DelegateSubtraction

namespace Root.General
{
    public class ControllerConnector : MonoBehaviour
    {
        [SerializeField] private ControlledEntity[] controlledEntities;
        [SerializeField] private bool manualControllers;
        public Controller[] controllers;

        private void Awake()
        {
            AssignControls();
        }

        private void AssignControls()
        {
            if (!manualControllers)
                controllers = FindObjectOfType<ControllerHandler>().GetConnectedControllersInOrder();
            if (controllers.Length < controlledEntities.Length)
            {
                throw new Exception("Not enough players connected");
            }

            for (int i = 0; i < controlledEntities.Length; i++)
            {
                controlledEntities[i].SetConnectedController(controllers[i]);
            }
        }
    }
}