using UnityEngine;
using System.Collections;

public class ServerBackend : MonoBehaviour
{
    public int      targetFrameRate     = 30;
    public int      maxConnection       = 64;
    public int      listenPort          = 8001;

    void Awake()
    {
        Application.targetFrameRate = targetFrameRate;
        uLink.Network.isAuthoritativeServer = true;
        uLink.Network.InitializeServer(maxConnection, listenPort);
    }

    private void uLink_OnServerInitialized()
    {
        Debug.Log("Server initialized on port " + listenPort);
    }
}
