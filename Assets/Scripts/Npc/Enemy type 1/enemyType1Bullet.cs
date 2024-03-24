using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyType1Bullet : MonoBehaviour
{
    
    public void EnemyShoot(Vector2 direction)
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = direction;
        }
    }
}
