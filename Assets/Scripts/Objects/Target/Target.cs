using UnityEngine;

public class TargetObject : MonoBehaviour, IDamagetable
{
    [SerializeField] private ParticleSystem targetBroken;

    public void BulletDamage() //The object hit by the bullet is destroyed
    {
        Destroy(gameObject);
        BrokenParticle();
    }


    private void BrokenParticle()
    {
        ParticleSystem targetBrokenParticle= Instantiate(targetBroken, transform.position, Quaternion.identity);
        Destroy(targetBrokenParticle.gameObject, 2f);

    }

}
