using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchTimelineManager : MonoBehaviour
{
    [SerializeField]private GameObject FutureTimeline;
    [SerializeField] private GameObject PastTimeline;

    private bool isPast;

    private void Start()
    {
        isPast= false;
        FutureTimeline.SetActive(true);
        PastTimeline.SetActive(false);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SwitchTimeline();
        }
    }

    private void SwitchTimeline()
    {
        if (!isPast)
        {
            isPast = true;
            FutureTimeline.SetActive(false);
            PastTimeline.SetActive(true);
        }
        else
        {
            isPast = false;
            FutureTimeline.SetActive(true);
            PastTimeline.SetActive(false);
        }
    }
}
