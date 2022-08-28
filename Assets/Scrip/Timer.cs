using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    float CurrentTime;
    public float LimitTime;
    public Text TimerText;

    private void Awake()
    {
        CurrentTime = LimitTime;
    }

    // Update is called once per frame
    void Update()
    {
        if(CurrentTime < 0)
        {
            if (TimerText)
            {
                TimerText.text = "е╦юс ╬ф©Т";
            }
            return;
        }
        CurrentTime -= Time.deltaTime;
        if (TimerText)
        {
            TimerText.text = CurrentTime.ToString() + " / " + LimitTime.ToString();
        }
    }
}
