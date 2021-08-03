using UnityEngine;
using UnityEngine.AI;
using Mirror;
using UnityEngine.UI;
using System.Collections;


public class Robot : NetworkBehaviour 
{
    [SyncVar] public float hp;

    [SerializeField] protected CharacterController controller;
    [SerializeField] protected AudioSource motorAudio;
    [SerializeField] protected float speed;
    [SerializeField] protected float rotationSpeed = 100;

    protected bool isShoot;

    [SerializeField] private Text hpText;
    [SerializeField] private Camera cam;
    [SerializeField] private GameObject UI;
    [SerializeField] private FloatingJoystick joystick;


    private void Start()
    {
        if (!isLocalPlayer)
        {
            cam.gameObject.SetActive(false);
            UI.SetActive(false);
        }
    }


    void FixedUpdate()
    {
       // if (hp < 0)
           // NetworkServer.Destroy(gameObject);

        if (!isLocalPlayer) return;


        float horizontal = Input.GetAxis("Horizontal");
        if (joystick) horizontal = joystick.Horizontal;

        transform.Rotate(0, horizontal * rotationSpeed * Time.deltaTime, 0);


        float vertical = Input.GetAxis("Vertical");
        if (joystick) vertical = joystick.Vertical;
        Vector3 forward = transform.TransformDirection(Vector3.forward);

        controller.Move(forward * vertical * speed);


        hpText.text = hp.ToString();

        if (horizontal != 0 || vertical != 0)
            motorAudio.enabled = true;
        else
            motorAudio.enabled = false;
    }

}
