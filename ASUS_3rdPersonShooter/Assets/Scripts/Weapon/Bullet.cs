using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float timeToDestroy;
    [HideInInspector] public WeaponManager weapon;

    [SerializeField] ParticleSystem explosion = null;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, timeToDestroy);
    }

    // Update is called once per frame

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponentInParent<EnemyHealth>())
        {
            EnemyHealth enemyHealth = collision.gameObject.GetComponentInParent<EnemyHealth>();
            enemyHealth.TakeDamage(weapon.damage);
        }
        this.gameObject.GetComponent<MeshRenderer>().enabled = false;
        this.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionX | 
            RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ;
        explosion.Play();
        Destroy(this.gameObject, 0.5f);
    }
}
