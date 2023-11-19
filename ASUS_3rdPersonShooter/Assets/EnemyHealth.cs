using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float health;

    [SerializeField] ParticleSystem explosion = null;
    public void TakeDamage(float damage)
    {
        if (health > 0)
        {
            health -= damage;
            if (health <= 0) EnemyDeath();
            Explode();
            Debug.Log("Hit");
        }
    }

    void EnemyDeath()
    {
        Destroy(this.gameObject);
        Explode();
        Debug.Log("Death");
    }

    public void Explode()
    {
        explosion.Play();
    }
}
