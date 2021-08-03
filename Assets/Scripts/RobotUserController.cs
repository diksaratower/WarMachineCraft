using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class RobotUserController : NetworkBehaviour
{
    public List<Weapon> weapons = new List<Weapon>();
    [SyncVar] public bool shootingForTest;//ради теста

    private void FixedUpdate()
    {


        if (shootingForTest)
            for (int i = 0; i < weapons.Count; i++)
                StartCoroutine(weapons[i].Shoot());
    }
    public void SetShoting()
    {
        if (!isLocalPlayer) return;

        Cmd_SetShoting(!shootingForTest);
    }

    [Command]
    public void Cmd_SetShoting(bool val)
    {

        shootingForTest = !shootingForTest;
    }
}
