using UnityEngine;

namespace Root.MainMenu.Scripts.Controls
{
  public class Controller : MonoBehaviour
  {
    public enum ButtonState
    {
      None,
      Pressed,
      Holding,
      Released
    }

    public ButtonState up;
    public ButtonState down;
    public ButtonState left;
    public ButtonState right;
    public ButtonState primary;
    public ButtonState secondary;

    [Header("Mapping")] [SerializeField] private KeyCode upMap;
    [SerializeField] private KeyCode downMap;
    [SerializeField] private KeyCode leftMap;
    [SerializeField] private KeyCode rightMap;
    [SerializeField] private KeyCode primaryMap;
    [SerializeField] private KeyCode secondaryMap;

    private void Update()
    {
      if (Input.GetKeyDown(upMap))
        up = ButtonState.Pressed;
      else if (Input.GetKeyUp(upMap))
        up = ButtonState.Released;
      else if (Input.GetKey(upMap))
        up = ButtonState.Holding;
      else
        up = ButtonState.None;

      if (Input.GetKeyDown(downMap))
        down = ButtonState.Pressed;
      else if (Input.GetKeyUp(downMap))
        down = ButtonState.Released;
      else if (Input.GetKey(downMap))
        down = ButtonState.Holding;
      else
        down = ButtonState.None;
      
      if (Input.GetKeyDown(leftMap))
        left = ButtonState.Pressed;
      else if (Input.GetKeyUp(leftMap))
        left = ButtonState.Released;
      else if (Input.GetKey(leftMap))
        left = ButtonState.Holding;
      else
        left = ButtonState.None;
      
      if (Input.GetKeyDown(rightMap))
        right = ButtonState.Pressed;
      else if (Input.GetKeyUp(rightMap))
        right = ButtonState.Released;
      else if (Input.GetKey(rightMap))
        right = ButtonState.Holding;
      else
        right = ButtonState.None;
      
      if (Input.GetKeyDown(primaryMap))
        primary = ButtonState.Pressed;
      else if (Input.GetKeyUp(primaryMap))
        primary = ButtonState.Released;
      else if (Input.GetKey(primaryMap))
        primary = ButtonState.Holding;
      else
        primary = ButtonState.None;
      
      if (Input.GetKeyDown(secondaryMap))
        secondary = ButtonState.Pressed;
      else if (Input.GetKeyUp(secondaryMap))
        secondary = ButtonState.Released;
      else if (Input.GetKey(secondaryMap))
        secondary = ButtonState.Holding;
      else
        secondary = ButtonState.None;
    }
  }
}