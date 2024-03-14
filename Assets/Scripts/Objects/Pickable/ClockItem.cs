using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockItem : MonoBehaviour,IPickable
{
    public void PickItem(HeroStorage storage)
    {
        storage.AddClocks();
        Destroy(this.gameObject);
    }
}
