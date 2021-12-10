/*
 * Author: Joaquín León Martínez
 * Date: 10/12/2021
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Class in charge of the T-Junction logic
 */
public class TJunction : Intersection
{
    #region Attributes

    // Number of cars on the road into which the cars at the intersection will join.
    private int carsOnTheRoad;

    public int CarsOnTheRoad
    {
        get { return carsOnTheRoad; }
        set { carsOnTheRoad = value; }
    }

    #endregion

    #region Methods

    // Redefines the condition to let the car leave the intersection.
    protected override bool CorrectConditions()
    {
        return carsOnTheRoad <= 0;
    }

    #endregion
}
