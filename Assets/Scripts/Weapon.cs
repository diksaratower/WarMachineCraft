using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public enum WeaponState {
        recharge,
        shoot,
        ready
    }

    [SerializeField] protected float _rechargeTime;
    [SerializeField] protected WeaponState _state;

    public virtual void Start()
    {
        transform.parent.GetComponent<RobotUserController>().weapons.Add(this);
    }

    public virtual IEnumerator Shoot()
    {
        if (_state == WeaponState.shoot || _state == WeaponState.recharge) yield break;
        _state = WeaponState.shoot;


        _state = WeaponState.shoot;

        _state = WeaponState.recharge;
        yield return new WaitForSeconds(_rechargeTime);
        _state = WeaponState.ready;
    }

}
