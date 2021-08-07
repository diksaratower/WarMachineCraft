using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using System;

public class ChatPlayer : NetworkBehaviour
{
    [SyncVar]
    public string playerName;

    public static event Action<ChatPlayer, string> OnMessage;

    private void Awake()
    {
        playerName = "test" + UnityEngine.Random.Range(0, 1000);
    }


    [Command]
    public void CmdSend(string message)
    {
        if (message.Trim() != "")
            RpcReceive(message.Trim());
    }

    [ClientRpc]
    public void RpcReceive(string message)
    {
        OnMessage?.Invoke(this, message);
    }
}
