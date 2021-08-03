using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lazer : Weapon
{
    [SerializeField] private GameObject bulletPref;
    [SerializeField] private List<Transform> trunks = new List<Transform>();

    public override void Start()
    {
        base.Start();
    }

    public override IEnumerator Shoot()
    {
        if (_state == WeaponState.shoot || _state == WeaponState.recharge) yield break;
        _state = WeaponState.shoot;
        for (int i = 0; i < trunks.Count; i++)
        {
            GameObject bullet = Instantiate(bulletPref, trunks[i].position, trunks[i].rotation);
        }
        _state = WeaponState.shoot;

        _state = WeaponState.recharge;
        yield return new WaitForSeconds(_rechargeTime);
        _state = WeaponState.ready;
    }
}
