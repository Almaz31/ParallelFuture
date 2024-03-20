using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class HeartItem : MonoBehaviour,IPickable
{
    [SerializeField] private VisualEffect visualEffect;
    public void PickItem(HeroStorage storage)
    {
        storage.AddHeart();
        visualEffect.Play();
        this.gameObject.SetActive(false);
        Destroy(this.gameObject,2f);
        Destroy(visualEffect.gameObject,2f);
    }
}
