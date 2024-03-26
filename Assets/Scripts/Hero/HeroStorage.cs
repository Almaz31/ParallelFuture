using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeroStorage : MonoBehaviour
{
    private int hearts;
    private int clocks;
    private int maxHealth = 100;
    private int health;
    public  int heroDamageBasicEnemies = 10;

    [SerializeField] Slider healthSlider;

 
    private void Awake()
    {
        health = maxHealth;     
        //hearts = 50;
        clocks = 10;
    }

    public void TakeDamage(int Takedamage)
    {
        health -= Takedamage;
        Debug.Log(health);
        healthSlider.value = health;
        HeroDeath();
    }
    public void AddHeart()
    {
        health = maxHealth;
        healthSlider.value = health;
        BaseUI.instance.UpdateHearts(hearts);
    }
    public void AddClocks()
    {
        clocks++;
        BaseUI.instance.UpdateClocks(clocks);
    }

    public void HeroDeath()
    {
        if (health <= 0) 
        {
            
            gameObject.SetActive(false);
        }
    }
}
