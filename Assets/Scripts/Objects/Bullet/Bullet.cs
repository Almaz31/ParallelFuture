
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private ParticleSystem bulletHitParticle;
    

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
        if (damagetable != null)
        {
            damagetable.BulletDamage();
            
            
        }
        if (collision.gameObject.CompareTag("Hero") || collision.gameObject.CompareTag("Bullet"))
        {
            return;
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
