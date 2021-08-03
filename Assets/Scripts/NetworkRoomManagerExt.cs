using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using Mirror;


[AddComponentMenu("")]
public class NetworkRoomManagerExt : NetworkRoomManager
{
    [Header("Spawner Setup")]
    [Tooltip("Reward Prefab for the Spawner")]
    public GameObject rewardPrefab;


    public override void OnRoomServerSceneChanged(string sceneName)
    {
        if (sceneName == RoomScene)
        {
            StartCoroutine(GoToGame());
        }
    }
    private IEnumerator GoToGame()
    {
        yield return new WaitForSeconds(10);
        ServerChangeScene(GameplayScene);

    }
    private void Update()
    {
        if (SceneManager.GetActiveScene().name == RoomScene && roomSlots.Count > 1)
            ServerChangeScene(GameplayScene);
    }

    public override bool OnRoomServerSceneLoadedForPlayer(NetworkConnection conn, GameObject roomPlayer, GameObject gamePlayer)
    {
        return true;
    }

    public override void OnRoomStopClient()
    {
        base.OnRoomStopClient();
    }

    public override void OnRoomStopServer()
    {
        base.OnRoomStopServer();
    }

    bool showStartButton;

    public override void OnRoomServerPlayersReady()
    {
#if UNITY_SERVER
            base.OnRoomServerPlayersReady();
#else
        showStartButton = false;
#endif
    }

    public override void OnGUI()
    {
        base.OnGUI();

        if (allPlayersReady && showStartButton && GUI.Button(new Rect(150, 300, 120, 20), "START GAME"))
        {
            showStartButton = false;

            ServerChangeScene(GameplayScene);
        }
    }
}

