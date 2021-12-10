using UnityEngine.SceneManagement;

namespace Root.MainMenu.Scripts.Connectors
{
    public class CartridgeConnectorHub : ConnectorHub
    {
        public override void Connect(string command)
        {
            string[] split = command.Split();
            if (split.Length != 2) return;
            if (split[0] != CommandList.Scene) return;

            //TODO temp
            SceneManager.LoadSceneAsync(int.Parse(split[1]));
        }

        public override void Disconnect()
        {
            //
        }
    }
}
