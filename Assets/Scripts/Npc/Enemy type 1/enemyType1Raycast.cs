using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Mathematics;

public class enemyType1Raycast : MonoBehaviour
{
    public float rotateSpeed;
    public float distance;


    public GameObject raycastTransform;

    public float magicSpeed = 6.0f;

    public float rangeRaycast;
    public Vector2 magicDirection = Vector2.right; // NPC'nin büyü atma yönü
    public GameObject magicPrefab; // Büyü Prefab'ý
    public Vector2 magicPointBreak;



    public GameObject parentObje; // Ebeveyn obje
    public GameObject childObject; // Alt obje


    /*private void //LateUpdate()
    {
        // Ebeveynin hareketine baðlý olarak alt nesnenin yerel dönüþ deðerlerini güncelle
        UpdateChildTransform();
    }

    private void UpdateChildTransform()
    {
        // Alt objenin ebeveyne baðlýlýðýný yeniler
        childObject.transform.localPosition = new Vector2(-0.08901686f, 0.1166667f);
        //childObject.transform.localRotation = Quaternion.identity;
    }*/

    private void Update()
    {
        raycastRotate();
        CastMagic();
    }


    void CastMagic()
    {
        LayerMask main = LayerMask.GetMask("main");//"player" tagýnda layer aranýcak.

        RaycastHit2D hit = Physics2D.Raycast(transform.position, magicDirection, distance, main);
        if (hit.collider != null && hit.collider.CompareTag("Hero"))
        {
            if (parentObje.transform.position.x > hit.collider.transform.position.x)
            {
                magicSpeed = math.abs(magicSpeed);
                // Büyü Prefab'ýný instantiate et
                GameObject magicInstance = Instantiate(magicPrefab, transform.position, Quaternion.Euler(magicPointBreak));

                // Büyüyü gönderilen yöne doðru yönlendir
                Rigidbody2D magicRigidbody = magicInstance.GetComponent<Rigidbody2D>();

                magicRigidbody.velocity = new Vector2(-magicSpeed, magicRigidbody.velocity.y);

                parentObje.GetComponent<SpriteRenderer>().flipX = true;



                Debug.DrawLine(transform.position, hit.point, Color.red);
                Debug.Log("temas var");

                // Örneðin: hit.collider.gameObject üzerinden hedefle ilgili iþlemler.
            }
            else
            {
                magicSpeed = -math.abs(magicSpeed);
                parentObje.GetComponent<SpriteRenderer>().flipX = false;
                GameObject magicInstance = Instantiate(magicPrefab, transform.position, Quaternion.Euler(magicPointBreak));

                // Büyüyü gönderilen yöne doðru yönlendir
                Rigidbody2D magicRigidbody = magicInstance.GetComponent<Rigidbody2D>();

                magicRigidbody.velocity = new Vector2(-magicSpeed, magicRigidbody.velocity.y);
            }
        }
        else
        {
            Debug.DrawLine(transform.position, transform.position + transform.right * distance, Color.green);


        }
    }
    private void raycastRotate()
    {
        // Objeyi döndür
        transform.Rotate(Vector3.forward * rotateSpeed * Time.deltaTime);

        // Raycast yönünü objenin dönüþüne göre güncelle, ÖNEMLÝ KOD KAYBETME!!
        magicDirection = Quaternion.Euler(0, 0, transform.rotation.eulerAngles.z) * Vector2.right;
    }
}
