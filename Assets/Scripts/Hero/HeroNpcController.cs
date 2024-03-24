using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Mathematics;

public class HeroNpcController : MonoBehaviour
{
    [SerializeField] float rotateSpeed;
    [SerializeField] float distance;

    [SerializeField] GameObject raycast;
    public enemyType1MovementAndShoot enemyShoot;
    [SerializeField] Transform HeroTransform;
    public bool isAttack = true;

    private void Awake()
    {
        //enemyShoot = GetComponentInChildren<enemyType1MovementAndShoot>(); 
    }
    private void Update()
    {
        RaycastRotate();
        HitEnemy();      
    }
    public void HitEnemy()
    {
        LayerMask Main = LayerMask.GetMask("Enemies");
        RaycastHit2D hit = Physics2D.Raycast(transform.position, raycast.transform.right, distance, Main);

        if(hit.collider!=null && hit.collider.CompareTag("Enemy"))
        {

            enemyShoot.EnemyAttack(transform.position);//referance fonks           
            Debug.DrawLine(transform.position, transform.position + transform.right * distance, Color.red);
        }   
    }
    private void RaycastRotate()
    {
        raycast.transform.Rotate(Vector3.forward * rotateSpeed * Time.deltaTime);

        raycast.transform.right = Quaternion.Euler(0, 0, transform.rotation.eulerAngles.z) * Vector2.right;

        Debug.DrawLine(transform.position, transform.position + transform.right * distance, Color.green);

    }
}
