using UnityEngine;
using System.Collections;

public class ShootBullets : MonoBehaviour
{
    [SerializeField] private float bulletSpeed = 3f;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform bulletSpawnPoint;
    private Vector2 direction = Vector2.right;
    public HeroMovement HeroMovement;

    [SerializeField] private float attackDelay = 0.5f;
    [SerializeField] private float reloadTime = 2f;
    [SerializeField] private byte bulletLimit = 7;

    private byte bulletCount;
    private bool isReloading = false;

    private void Awake()
    {
        HeroMovement = GetComponent<HeroMovement>();
        bulletCount = bulletLimit;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.X) && bulletCount > 0 && !isReloading)
        {
            StartCoroutine(ShootLoop());
        }
    }

    private void FireBullet() 
    {
        Quaternion rotation = Quaternion.Euler(0, 0, HeroMovement.flip ? -90 : 90);
        Vector2 shootDirection = HeroMovement.flip ? direction : -direction;

        GameObject bulletInstance = Instantiate(bulletPrefab, bulletSpawnPoint.position, rotation);
        Bullet bullet = bulletInstance.GetComponent<Bullet>();

        bullet.Shoot(shootDirection * bulletSpeed);
        Destroy(bulletInstance.gameObject, 6f);
    }

    private IEnumerator ShootLoop()
    {
        bulletCount--;
        FireBullet(); 
        yield return new WaitForSeconds(attackDelay);

        
        while (Input.GetKey(KeyCode.X))
        {
            if (bulletCount <= 0)
            {
                
                StartCoroutine(Reload());
                yield break;
            }

            bulletCount--;
            FireBullet(); 
            yield return new WaitForSeconds(attackDelay);
        }
    }

    private IEnumerator Reload()
    {
        isReloading = true;
        yield return new WaitForSeconds(reloadTime);
        bulletCount = bulletLimit; 
        isReloading = false;
    }

    
    public void SetBulletLimit(byte newLimit)
    {
        bulletLimit = newLimit;
        bulletCount = bulletLimit;
    }
}
