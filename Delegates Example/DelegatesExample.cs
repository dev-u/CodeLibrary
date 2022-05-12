using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelegatesExample : MonoBehaviour
{
    private Action attackFunction;

    private void Start ()
    {
        // Defaults to punch
        attackFunction = PunchAttack;
    }

    private void Update ()
    {
        if (Input.GetKeyDown("Fire1"))
        {
            attackFunction();
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            // F switches to sword
            SetAttackFunction(SwordAttack);
        }
        
        if (Input.GetKeyDown(KeyCode.G))
        {
            // G switches to bow
            SetAttackFunction(BowAttack);
        }

        if (Input.GetKeyDown(KeyCode.H))
        {
            // H switches to punch
            SetAttackFunction(PunchAttack);
        }
    }

    private void SetAttackFunction (Action newAttackFunction)
    {
        attackFunction = newAttackFunction;
    }

    private void PunchAttack ()
    {
        Debug.Log("Punch attack!");
    }

    private void SwordAttack ()
    {
        Debug.Log("Sword attack!");
    }

    private void BowAttack ()
    {
        Debug.Log("Bow attack!");
    }

}