using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class enemyType1MovementAndShoot : MonoBehaviour
{
    [SerializeField] GameObject enemyType1Bullet;
    [SerializeField] Transform enemyGunPos;
    [SerializeField] Transform targetHero;
    public HeroNpcController heroNpcController;
   
    
    [SerializeField] float shootSpeed; 
    [SerializeField] float speedEnemy = 5f;
    [SerializeField] float attackRange = 5f;

    private void Update()
    {
        NPCTarget();
    }
    public void EnemyAttack(Vector3 heroPoz)
    {
        if (enemyGunPos != null && enemyType1Bullet != null )
        {            
            GameObject bulletInstance = Instantiate(enemyType1Bullet, enemyGunPos.position, Quaternion.identity);
            enemyType1Bullet bullet = bulletInstance.GetComponent<enemyType1Bullet>();

            Vector3 shootDirection = (heroPoz - enemyGunPos.position).normalized; //**

            bullet.EnemyShoot(shootDirection * shootSpeed);
            
        }             
    }
    void NPCTarget()
    {       
        float distanceToTarget = Mathf.Abs(transform.position.x - targetHero.position.x);
     
        if (distanceToTarget > attackRange) // tolerance
        {           
            float directionToTargetX = Mathf.Sign(targetHero.position.x - transform.position.x);
            //Quaternion rotation = Quaternion.Euler(0, Mathf.Sign(directionToTargetX)<0 ? 180 : -180 , 0);
            Vector3 moveVector = new Vector3(directionToTargetX * speedEnemy * Time.deltaTime, 0f, 0f);

            //transform.rotation = rotation;
            transform.Translate(moveVector);
        }
    }

}
