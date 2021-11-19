using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConnectorHub : MonoBehaviour
{
    [SerializeField] private float connectorSize; // How far away the connector can be before it connects

    public float GetConnectorSize()
    {
        return connectorSize;
    }
}
