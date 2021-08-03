using UnityEngine;

namespace Mirror.Examples.Tanks
{
    public class Projectile : NetworkBehaviour
    {
        public float destroyAfter = 5;
        public Rigidbody rigidBody;
        public GameObject efectPrefab;
        public float force = 1000;
        public float damage;

        public override void OnStartServer()
        {
            Invoke(nameof(DestroySelf), destroyAfter);
        }

        // set velocity for server and client. this way we don't have to sync the
        // position, because both the server and the client simulate it.
        void Start()
        {
            rigidBody.AddForce(transform.forward * force);
        }

        // destroy for everyone on the server
        [Server]
        void DestroySelf()
        {
            NetworkServer.Destroy(gameObject);
        }

        // ServerCallback because we don't want a warning if OnTriggerEnter is
        // called on the client
        [ServerCallback]
        void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.GetComponent<Tank>())
                collision.gameObject.GetComponent<Tank>().hp -= damage;
            GameObject efect = Instantiate(efectPrefab, transform.position, transform.rotation);
            NetworkServer.Spawn(efect);
            NetworkServer.Destroy(gameObject);
        }
    }
}
