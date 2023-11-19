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
        }
    }

    void EnemyDeath()
    {
        explosion.Play();
        foreach (Transform child in transform)
            if (child.gameObject.name != "enemy_explosion")
            {
                child.gameObject.SetActive(false);
            }
        this.gameObject.GetComponent<SphereCollider>().enabled = false;
        Destroy(this.gameObject, 0.5f);
        Debug.Log("Death");
    }

    public void Explode()
    {
        explosion.Play();
    }
}
