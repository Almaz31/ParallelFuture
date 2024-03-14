using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartItem : MonoBehaviour,IPickable
{
    public void PickItem(HeroStorage storage)
    {
        storage.AddHeart();
        Destroy(this.gameObject);
    }
}
