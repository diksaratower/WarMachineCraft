using UnityEngine;
using UnityEngine.AI;
using Mirror;
using UnityEngine.UI;
using System.Collections;


public class Tank : NetworkBehaviour 
{
    [SyncVar] public float hp;

    [SerializeField] protected CharacterController controller;
    [SerializeField] protected AudioSource motorAudio;
    [SerializeField] protected float speed;
    [SerializeField] protected float turretRotSpeed;
    [SerializeField] protected float rotationSpeed = 100;
    [SerializeField] protected GameObject turret;

    protected bool isShoot;

    [SerializeField] private KeyCode shootKey = KeyCode.Space;
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private Transform projectileMount;
    [SerializeField] private Text hpText;
    [SerializeField] private Image cannonFil;
    [SerializeField] private Camera cam;
    [SerializeField] private GameObject UI;
    [SerializeField] private GameObject nick;
    [SerializeField] private FloatingJoystick joystick;


    private void Start()
    {
        if (!isLocalPlayer)
        {
            cam.gameObject.SetActive(false);
            UI.SetActive(false);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(shootKey))
        {
            if (!isLocalPlayer) return;
            StartCoroutine(shoot());
        }
    }
    void FixedUpdate()
    {
        if (hp < 0)
            NetworkServer.Destroy(gameObject);

        if (!isLocalPlayer) return;


        float horizontal = Input.GetAxis("Horizontal");
        if (joystick) horizontal = joystick.Horizontal;

        transform.Rotate(0, horizontal * rotationSpeed * Time.deltaTime, 0);


        float vertical = Input.GetAxis("Vertical");
        if (joystick) vertical = joystick.Vertical;
        Vector3 forward = transform.TransformDirection(Vector3.forward);

        controller.Move(forward * vertical * speed);

        if (Input.GetKey(KeyCode.Alpha9))
            turret.transform.localEulerAngles = new Vector3(turret.transform.localEulerAngles.x, turret.transform.localEulerAngles.y + 0.8f, turret.transform.localEulerAngles.z);
        if (Input.GetKey(KeyCode.Alpha0))
            turret.transform.localEulerAngles = new Vector3(turret.transform.localEulerAngles.x, turret.transform.localEulerAngles.y - 0.8f, turret.transform.localEulerAngles.z);
        hpText.text = hp.ToString();

        if (horizontal != 0 || vertical != 0)
            motorAudio.enabled = true;
        else
            motorAudio.enabled = false;
    }


    [Command(requiresAuthority = false)]
    public void CmdFire()
    {
        GameObject projectile = Instantiate(projectilePrefab, projectileMount.position, projectileMount.rotation);
        NetworkServer.Spawn(projectile);
    }
    public void ShootForBTN()
    {
        StartCoroutine(shoot());
    }
    public virtual IEnumerator shoot()
    {
        if (isShoot)
            yield break;
        isShoot = true;
        CmdFire();
        cannonFil.fillAmount = 0;
        for (int i = 0; i < 100; i++)
        {
            if (isLocalPlayer)
                cannonFil.fillAmount += 0.01f;
            yield return new WaitForSeconds(0.03f);
        }
        isShoot = false;
    }
}
