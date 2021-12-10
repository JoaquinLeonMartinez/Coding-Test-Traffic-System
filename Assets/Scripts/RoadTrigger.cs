/*
 * Author: Joaquín León Martínez
 * Date: 10/12/2021
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Class to support T-Junctions, defines an extra trigger to check before to start the cars waiting again.
 */
public class RoadTrigger : MonoBehaviour
{
    #region Attributes
    // Reference to his TJunction
    [SerializeField]
    private TJunction tjunction;

    #endregion

    #region Methods

    private void OnTriggerEnter(Collider other)
    {
        // Increases the car counter by one
        if (other.isTrigger)
        {
            return;
        }
        CarAI currentCar = other.gameObject?.GetComponent<CarAI>();
        if (currentCar == null)
        {
            return;
        }

        tjunction.CarsOnTheRoad++;
    }

    private void OnTriggerExit(Collider other)
    {
        // Decreases the car counter by one
        if (other.isTrigger)
        {
            return;
        }
        CarAI currentCar = other.gameObject?.GetComponent<CarAI>();
        if (currentCar == null)
        {
            return;
        }

        tjunction.CarsOnTheRoad--;
    }

    #endregion

}
