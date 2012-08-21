using UnityEngine;
using System.Collections;

public class ClientBackend : MonoBehaviour
{
    public int      targetFrameRate     = 30;

    public bool     directConnect       = false;
    public string   directConnectIP     = "127.0.0.1";
    public int      directConnectPort   = 8001;

    void Awake()
    {
        Application.targetFrameRate = targetFrameRate;
        uLink.Network.isAuthoritativeServer = true;

    }

    void Update()
    {
        if(directConnect && uLink.Network.status == uLink.NetworkStatus.Disconnected)
        {
            uLink.Network.Connect(directConnectIP, directConnectPort);
            Debug.Log("Connecting to server at ip : " + directConnectIP + " on port " + directConnectPort);
        }

    }
    private void uLink_OnConnectedToServer()
    {
        Debug.Log("Connected to server");
    }

    private void uLink_OnDisconnectedFromServer()
    {
        Debug.Log("Disconnected from server");
    }

    private void uLink_OnFailedToConnect()
    {
        Debug.Log("Failed to connect");
    }
}
