using System;
using UnityEngine;

namespace Controls
{
    public class Controller : MonoBehaviour
    {
        public enum ButtonState
        {
            Pressed,
            //Holding,
            Released
        }
    
        public Action<ButtonState> up;
        public Action<ButtonState> down;
        public Action<ButtonState> left;
        public Action<ButtonState> right;
        public Action<ButtonState> primary;
        public Action<ButtonState> secondary;

        [Header("Mapping")] 
        [SerializeField] private KeyCode upMap;
        [SerializeField] private KeyCode downMap;
        [SerializeField] private KeyCode leftMap;
        [SerializeField] private KeyCode rightMap;
        [SerializeField] private KeyCode primaryMap;
        [SerializeField] private KeyCode secondaryMap;

        private void Update()
        {
            if (Input.GetKeyDown(upMap))
            {
                up?.Invoke(ButtonState.Pressed);
            }
            else if (Input.GetKeyUp(upMap))
            {
                up?.Invoke(ButtonState.Released);
            }

            if (Input.GetKeyDown(downMap))
            {
                down?.Invoke(ButtonState.Pressed);
            }
            else if (Input.GetKeyUp(downMap))
            {
                down?.Invoke(ButtonState.Released);
            }

            if (Input.GetKeyDown(leftMap))
            {
                left?.Invoke(ButtonState.Pressed);
            }
            else if (Input.GetKeyUp(leftMap))
            {
                left?.Invoke(ButtonState.Released);
            }

            if (Input.GetKeyDown(rightMap))
            {
                right?.Invoke(ButtonState.Pressed);
            }
            else if (Input.GetKeyUp(rightMap))
            {
                right?.Invoke(ButtonState.Released);
            }

            if (Input.GetKeyDown(primaryMap))
            {
                primary?.Invoke(ButtonState.Pressed);
            }
            else if (Input.GetKeyUp(primaryMap))
            {
                primary?.Invoke(ButtonState.Released);
            }

            if (Input.GetKeyDown(secondaryMap))
            {
                secondary?.Invoke(ButtonState.Pressed);
            }
            else if (Input.GetKeyUp(secondaryMap))
            {
                secondary?.Invoke(ButtonState.Released);
            }
        }
    }
}
