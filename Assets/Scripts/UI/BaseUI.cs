using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BaseUI : MonoBehaviour
{
    public static BaseUI instance;

    [SerializeField] private TextMeshProUGUI heartText;
    [SerializeField] private TextMeshProUGUI clocksText;


    private void Start()
    {
        instance = this;
    }
    public void UpdateHearts(int number) {
        heartText.text = number.ToString();
    }
    public void UpdateClocks(int number)
    {
        clocksText.text = number.ToString();
    }
}
