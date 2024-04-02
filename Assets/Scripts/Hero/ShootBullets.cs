using UnityEngine;
using System.Collections;

public class ShootBullets : MonoBehaviour
{
    [SerializeField] private float bulletSpeed = 3f;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform bulletSpawnPoint;
    private Vector2 directionShot = Vector2.right;
    public HeroMovement HeroMovement;

    [SerializeField] private float attackDelay = 0.5f;
    [SerializeField] private float reloadTime = 2f;
    [SerializeField] private byte bulletLimit = 7;

    private byte bulletCount;
    private bool isReloading = false;
    private bool isShooting = false;

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

        if (Input.GetKeyUp(KeyCode.X))
        {
            isShooting = false; 
        }
    }


    public void FireBullet()
    {
        Quaternion rotation = Quaternion.Euler(0, 0, HeroMovement.flip ? -90 : 90);//bullet rotate
        Vector2 shootDirection = HeroMovement.flip ? directionShot : -directionShot; //referance heroMovement

        GameObject bulletInstance = Instantiate(bulletPrefab, bulletSpawnPoint.position, rotation);
        BulletHero bullet = bulletInstance.GetComponent<BulletHero>();

        bullet.Shoot(shootDirection * bulletSpeed);
        Destroy(bulletInstance.gameObject, 6f);
    }

    public IEnumerator ShootLoop()
    {
        isShooting = true; //start fire

        while (isShooting && bulletCount > 0 && !isReloading)
        {
            FireBullet(); //fire

            bulletCount--; 

            if (bulletCount == 0)
            {
                StartCoroutine(Reload()); 
                break;
            }

            yield return new WaitForSeconds(attackDelay); 
        }
    }

    public void PushAttackMobile()
    {
        if ( bulletCount > 0 && !isReloading)
        {
            StartCoroutine(ShootLoop());
        }

        if (isReloading)
        {
            isShooting = false;
        }
    }

    public void ReleaseAttackMobile()
    {
        isShooting = false;
    }

private IEnumerator Reload()
    {
        isReloading = true; //reload start

        yield return new WaitForSeconds(reloadTime); //reloadtime

        bulletCount = bulletLimit; 
        isReloading = false; 
    }

  
}
