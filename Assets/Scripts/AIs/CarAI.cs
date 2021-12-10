/*
 * Author: Joaquín León Martínez
 * Date: 10/12/2021
 */
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Class in charge of car behavior. Most of the logic is in the parent class, in future extensions some of those behaviors would have to be adapted.
 */
public class CarAI : AIBehavior
{
    #region Methods
    // Check the collision with other cars, stop before the collision.
    private void OnTriggerEnter(Collider other)
    {
        if (other.isTrigger)
        {
            return;
        }

        if (other.gameObject?.GetComponent<CarAI>() != null)
        {
            Stop = true;
        }
    }

    // Check if the other car is out of range.
    private void OnTriggerExit(Collider other)
    {
        if (other.isTrigger)
        {
            return;
        }

        if (other.gameObject?.GetComponent<CarAI>() != null)
        {
            Stop = false;
        }
    }
    #endregion
}
