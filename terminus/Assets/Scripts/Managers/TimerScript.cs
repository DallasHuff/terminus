using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using TMPro;


public class TimerScript : MonoBehaviour
{
    public float timeRemaining = 60;
    [SerializeField] TextMeshProUGUI timerTMPro;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timerTMPro.SetText("Timer: " + Mathf.Floor(timeRemaining));
        
        if (timeRemaining > 0)
        {
            timeRemaining -=  Time.deltaTime;
        }
        else
        {
            Debug.Log("You are all out of timeow!");
        }
    }
}
