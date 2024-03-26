using UnityEngine;

public class HealthBarFollow : MonoBehaviour
{
    public Transform targetCharacter;

    void LateUpdate()
    {
        // Health bar'ýn pozisyonunu karakterin pozisyonuna eþitle
        if (targetCharacter != null)
        {
            transform.position = targetCharacter.position;
        }

        // Health bar'ýn dönüþünü sýfýrla
        transform.localRotation = Quaternion.identity;
    }
}