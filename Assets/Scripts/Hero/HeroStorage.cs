using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroStorage : MonoBehaviour
{
    private int hearts;
    private int clocks;

    private void Start()
    {
        hearts = 10;
        clocks = 10;
    }
    public void AddHeart()
    {
        hearts++;
        BaseUI.instance.UpdateHearts(hearts);
    }
    public void AddClocks()
    {
        clocks++;
        BaseUI.instance.UpdateClocks(clocks);
    }
}
