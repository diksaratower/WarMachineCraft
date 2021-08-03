using UnityEngine;
using Mirror;


[AddComponentMenu("")]
public class NetworkRoomPlayerExt : NetworkRoomPlayer
{
    public override void OnStartClient()
    {
        // Debug.LogFormat(LogType.Log, "OnStartClient {0}", SceneManager.GetActiveScene().path);

        base.OnStartClient();
    }

    public override void OnClientEnterRoom()
    {
        // Debug.LogFormat(LogType.Log, "OnClientEnterRoom {0}", SceneManager.GetActiveScene().path);
    }

    public override void OnClientExitRoom()
    {
        // Debug.LogFormat(LogType.Log, "OnClientExitRoom {0}", SceneManager.GetActiveScene().path);
    }

    public override void ReadyStateChanged(bool oldReadyState, bool newReadyState)
    {
        // Debug.LogFormat(LogType.Log, "ReadyStateChanged {0}", newReadyState);
    }

    public override void OnGUI()
    {
        if (!showRoomGUI)
            return;

        NetworkRoomManager room = NetworkManager.singleton as NetworkRoomManager;
        if (room)
        {
            if (!room.showRoomGUI)
                return;

            if (!NetworkManager.IsSceneActive(room.RoomScene))
                return;
            if (NetworkClient.active && isLocalPlayer)
            {
                GUILayout.BeginArea(new Rect(20f + (index * 100), 200f, 90f, 130f));

                GUILayout.Label($"Player [{index + 1}]");


                GUILayout.Label("Nick: ???");
                GUILayout.EndArea();
            }
        }
    }
}

