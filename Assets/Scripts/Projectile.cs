using System.Collections;
using UnityEngine;
using Mirror;

public class Projectile : NetworkBehaviour
{
    public float destroyAfter = 5;
    public Rigidbody rigidBody;
    public GameObject efectPrefab;
    public float force = 1000;
    public float damage;

    protected virtual void Start()
    {
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
        ///NetworkServer.Destroy(gameObject);
    }
}

