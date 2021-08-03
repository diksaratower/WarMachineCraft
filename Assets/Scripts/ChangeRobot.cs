using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using Mirror.Examples.NetworkRoom;

public class ChangeRobot : MonoBehaviour
{
    private NetworkRoomManagerExt _networkManager;

    private void Start()
    {
        _networkManager = FindObjectOfType<NetworkRoomManagerExt>();
    }

    public void changeRobot(GameObject newRobot)
    {
        _networkManager.playerPrefab = newRobot;
    }
}
