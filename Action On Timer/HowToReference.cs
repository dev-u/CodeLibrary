using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HowToReference : MonoBehaviour 
{
    // Calling the action class
    [SerializeField] private ActionOnTimer actionOnTimer;
    
    // Cooldown time, set via inspector
    [SerializeField] private float cooldownTimerExample;

    private void Start() 
    {
        // Callback
        actionOnTimer.SetTimer(cooldownTimerExample, DoSomething);

        // Lambda
        actionOnTimer.SetTimer(cooldownTimerExample, () => { Debug.Log("Did something!"); });
    }
    
    private void DoSomething ()
    {
        // Do something here
    }
}