using System.Collections.Generic;
using UnityEngine;

namespace Root.MainMenu.Scripts.Controls
{
  public class ControllerHandler : MonoBehaviour
  {
    [SerializeField] private Controller[] controllers;

    private List<Controller> connectedControllers = new List<Controller>();

    // For looking up which controller is which player
    private Dictionary<int, Controller> playerMapping = new Dictionary<int, Controller>();

    private void Awake()
    {
      DontDestroyOnLoad(this);
      if (FindObjectsOfType<ControllerHandler>().Length > 1)
      {
        Destroy(gameObject);
        return;
      }
      
      connectedControllers.Clear();
      playerMapping.Clear();
    }

    public void ConnectController(int port, int controller)
    {
      playerMapping.Add(port, controllers[controller]);
      connectedControllers.Add(controllers[controller]);

      //controllers[controller].primary += TestPrint;
    }

    public void DisconnectController(int port)
    {
      if (!playerMapping.ContainsKey(port)) return;
      
      //playerMapping[port].primary -= TestPrint;
      
      connectedControllers.Remove(playerMapping[port]);
      playerMapping.Remove(port);
    }

    // Returns connected controllers in the order of port index
    public Controller[] GetConnectedControllersInOrder()
    {
      Controller[] sortedControllers = new Controller[connectedControllers.Count];
      int mapCount = 0;
      for (int i = 0; i < connectedControllers.Count; i++)
      {
        while (!playerMapping.ContainsKey(mapCount))
        {
          mapCount++;
        }

        sortedControllers[i] = playerMapping[mapCount];
      }
      return sortedControllers;
    }

    private void TestPrint(Controller.ButtonState test)
    {
      print("Primary " + test);
    }
  }
}