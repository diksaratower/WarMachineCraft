using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class TankAI : Robot
{
    [SerializeField] private Robot target;
    [SerializeField] private float stopDistance;
    /*
    private void FixedUpdate()
    {
        if (!target)
        {
            target = GameObject.FindObjectOfType<Robot>();
            return;
        }
        if (hp < 0)
            NetworkServer.Destroy(gameObject);

        
        float horizontal = 0;
        transform.Rotate(0, horizontal * rotationSpeed * Time.deltaTime, 0);

        float vertical = 0;
        Vector3 forward = transform.TransformDirection(Vector3.forward);

        if(Vector3.Distance(target.transform.position, transform.position) > stopDistance)
            controller.Move(forward * speed);


        Vector3 dir = target.transform.position - turret.transform.position;
        Quaternion rot = Quaternion.LookRotation(dir);
        turret.transform.rotation = Quaternion.Slerp(turret.transform.rotation, rot, turretRotSpeed * Time.deltaTime);
        turret.transform.localEulerAngles = new Vector3(-90, turret.transform.localEulerAngles.y, turret.transform.localEulerAngles.z);

        transform.rotation = Quaternion.Slerp(transform.rotation, rot, rotationSpeed * Time.deltaTime);
        transform.localEulerAngles = new Vector3(0, transform.localEulerAngles.y, 0);

        StartCoroutine(shoot());

        if (horizontal != 0 || vertical != 0)
            motorAudio.enabled = true;
        else
            motorAudio.enabled = false;
    }
    public override IEnumerator shoot()
    {
        if (isShoot)
            yield break;
        isShoot = true;
        CmdFire();
        for (int i = 0; i < 100; i++)
        {
            yield return new WaitForSeconds(0.03f);
        }
        isShoot = false;
    }
    */
}
