using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyType1Bullet : MonoBehaviour
{
    [SerializeField] int bulletDamage = 3;
 
    public void EnemyShoot(Vector2 direction)
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = direction;
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Hero"))
        {
            HeroStorage heroStorageInstance = collision.GetComponent<HeroStorage>();
            if (heroStorageInstance != null)
            {
                heroStorageInstance.TakeDamage(bulletDamage);
            }
            gameObject.SetActive(false);
            Destroy(gameObject, 2f);
        }
        else
        {
           
            Destroy(gameObject, 6f);
        }
    }

}
