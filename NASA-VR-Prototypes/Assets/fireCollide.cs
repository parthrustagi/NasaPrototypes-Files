using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;

public class fireCollide : MonoBehaviour
{
    public static Collider fireCollider;
    private static Timer startTime;
    private static Timer stopTime;
    // Start is called before the first frame update
    void Start()
    {
        fireCollider= GetComponent<Collider>();

        // Create a timer and set a two second interval.
        startTime = new System.Timers.Timer();
        startTime.Interval = 5000;

        // Hook up the Elapsed event for the timer. 
        //startTime.Elapsed += OnEvent;

        // Have the timer fire repeated events (true is the default)
        startTime.AutoReset = true;

        // Start the timer
        startTime.Enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private static void OnEvent(Object source, System.Timers.ElapsedEventArgs e)
    {
        fireCollider.enabled = true;

        //timer
        stopTime = new System.Timers.Timer();
        stopTime.Interval =1500;

        // Hook up the Elapsed event for the timer. 
        //stopTime.Elapsed += OffEvent;

        // Have the timer fire repeated events (true is the default)
        stopTime.AutoReset = false;

        // Start the timer
        stopTime.Enabled = true;
    }
    private static void OffEvent(Object source, System.Timers.ElapsedEventArgs e)
    {
        fireCollider.enabled = false;
        stopTime.Stop();
    }
}
