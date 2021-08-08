using System.Collections;
using UnityEngine;
using Mirror;

public class Projectile : NetworkBehaviour
{
    [SerializeField] private float destroyAfter = 5;
    [SerializeField] private GameObject efectPrefab;
    [SerializeField] private float force = 1000;
    [SerializeField] private float damage;

    private Rigidbody rigidBody;

    protected virtual void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        StartCoroutine(destroyObj());
        rigidBody.AddForce(transform.forward * force);
    }

    protected IEnumerator destroyObj()
    {
        yield return new WaitForSeconds(destroyAfter);
        Destroy(gameObject);
    }

    [ServerCallback]
    protected void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Robot>())
            collision.gameObject.GetComponent<Robot>().hp -= damage;
        if (efectPrefab)
        {
            GameObject efect = Instantiate(efectPrefab, transform.position, transform.rotation);
            NetworkServer.Spawn(efect);
        }
    }
}

