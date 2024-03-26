using UnityEngine;
using UnityEngine.UI;

public class TargetBasicEnemies : MonoBehaviour, IDamagetable
{
    private Rigidbody2D enemyRb2;
    [SerializeField] float heroHitShake = 2f;
    public Slider HealthBar;

    [SerializeField] int maxHealth = 100;
    [SerializeField] int health;

    void Awake()
    {
        health = maxHealth;
        enemyRb2 = GetComponent<Rigidbody2D>();
    }

    public void BulletDamageBasicEnemies(int takeDamage) 
    {
        health -= takeDamage;
        if ( HealthBar != null)
        {
            HealthBar.value = health;
        }
        
    }

    public void BasicEnemiesDeath()
    {
        if (health <= 0)
        {
            gameObject.SetActive(false);
            Destroy(gameObject, 3f); return;
        }
    }





   /*private void BrokenParticle()
    {
        ParticleSystem targetBrokenParticle= Instantiate(targetBroken, transform.position, Quaternion.identity);
        Destroy(targetBrokenParticle.gameObject, 2f);

    }*/

}
