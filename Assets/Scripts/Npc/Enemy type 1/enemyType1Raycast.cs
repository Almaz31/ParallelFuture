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
    public Vector2 magicDirection = Vector2.right; // NPC'nin b�y� atma y�n�
    public GameObject magicPrefab; // B�y� Prefab'�
    public Vector2 magicPointBreak;



    public GameObject parentObje; // Ebeveyn obje
    public GameObject childObject; // Alt obje


    /*private void //LateUpdate()
    {
        // Ebeveynin hareketine ba�l� olarak alt nesnenin yerel d�n�� de�erlerini g�ncelle
        UpdateChildTransform();
    }

    private void UpdateChildTransform()
    {
        // Alt objenin ebeveyne ba�l�l���n� yeniler
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
        LayerMask main = LayerMask.GetMask("main");//"player" tag�nda layer aran�cak.

        RaycastHit2D hit = Physics2D.Raycast(transform.position, magicDirection, distance, main);
        if (hit.collider != null && hit.collider.CompareTag("Hero"))
        {
            if (parentObje.transform.position.x > hit.collider.transform.position.x)
            {
                magicSpeed = math.abs(magicSpeed);
                // B�y� Prefab'�n� instantiate et
                GameObject magicInstance = Instantiate(magicPrefab, transform.position, Quaternion.Euler(magicPointBreak));

                // B�y�y� g�nderilen y�ne do�ru y�nlendir
                Rigidbody2D magicRigidbody = magicInstance.GetComponent<Rigidbody2D>();

                magicRigidbody.velocity = new Vector2(-magicSpeed, magicRigidbody.velocity.y);

                parentObje.GetComponent<SpriteRenderer>().flipX = true;



                Debug.DrawLine(transform.position, hit.point, Color.red);
                Debug.Log("temas var");

                // �rne�in: hit.collider.gameObject �zerinden hedefle ilgili i�lemler.
            }
            else
            {
                magicSpeed = -math.abs(magicSpeed);
                parentObje.GetComponent<SpriteRenderer>().flipX = false;
                GameObject magicInstance = Instantiate(magicPrefab, transform.position, Quaternion.Euler(magicPointBreak));

                // B�y�y� g�nderilen y�ne do�ru y�nlendir
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
        // Objeyi d�nd�r
        transform.Rotate(Vector3.forward * rotateSpeed * Time.deltaTime);

        // Raycast y�n�n� objenin d�n���ne g�re g�ncelle, �NEML� KOD KAYBETME!!
        magicDirection = Quaternion.Euler(0, 0, transform.rotation.eulerAngles.z) * Vector2.right;
    }
}
