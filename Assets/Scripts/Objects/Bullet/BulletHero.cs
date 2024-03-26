using System.Collections;
using UnityEngine;

public class BulletHero : MonoBehaviour
{
    [SerializeField] private ParticleSystem bulletHitParticle;
    HeroStorage heroStorage;
    private int hitDamage;
    private void Awake()
    {
        heroStorage = FindAnyObjectByType<HeroStorage>();
        hitDamage = heroStorage.heroDamageBasicEnemies;
    }
    public void Shoot(Vector2 direction)
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = direction;
        }       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        IDamagetable damagetable = collision.GetComponent<IDamagetable>();
        if (damagetable != null )
        {
            TargetBasicEnemies targetBasicEnemies = collision.GetComponent<TargetBasicEnemies>();

            if (targetBasicEnemies != null)
            {
                targetBasicEnemies.BulletDamageBasicEnemies(hitDamage);
            }
            targetBasicEnemies.BasicEnemiesDeath(); //enemies death Check
       
        }

        if (!collision.gameObject.CompareTag("Enemy"))
        {
            return ;
        }

        BulletHitParticle();
        gameObject.SetActive(false);
        Destroy(gameObject, 2f);
    }


    public void BulletHitParticle()
    {
        ParticleSystem bulletsHitParticle = Instantiate(bulletHitParticle, transform.position, Quaternion.identity);
        Destroy(bulletsHitParticle.gameObject, 2f);
    }
}
