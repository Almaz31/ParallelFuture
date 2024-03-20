using UnityEngine;

public class ShootBullets : MonoBehaviour
{
    [SerializeField] private float bulletSpeed = 3f;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform bulletSpawnPoint;
    private Vector2 direction = Vector2.right;
    public HeroMovement HeroMovement;

    private void Awake()
    {     
        HeroMovement = GetComponent<HeroMovement>();//caching
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            ShootBullet();
        }
    }

    private void ShootBullet()
    {

        if (HeroMovement.flip)
        {
            GameObject bulletInstance = Instantiate(bulletPrefab, bulletSpawnPoint.position, Quaternion.Euler(0, 0, -90));
            Bullet bullet = bulletInstance.GetComponent<Bullet>();
            bullet.Shoot(direction * bulletSpeed);
            Destroy(bulletInstance.gameObject, 6f);
            
        }
        else if (!HeroMovement.flip)
        {
            GameObject bulletInstance = Instantiate(bulletPrefab, bulletSpawnPoint.position, Quaternion.Euler(0, 0, 90));
            Bullet bullet = bulletInstance.GetComponent<Bullet>();
            bullet.Shoot(-direction * bulletSpeed);
            Destroy(bulletInstance.gameObject, 6f);

        }

    }
}
