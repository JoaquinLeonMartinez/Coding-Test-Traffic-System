using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Class in charge of the Pedestrian Crossing logic
 */
public class PedestrianCrossing : Intersection
{
    #region Attributes

    // Number of pedestrians crossing
    private int pedestriansCrossing;

    #endregion

    #region Methods

    // Redefine the Action for this case, we want to activate all cars on standby (there will be a maximum of two, one in each direction)
    protected override void Action()
    {
        DequeueAll();
    }

    // Dequeue all cars waiting
    private void DequeueAll()
    {
        int lenght = carsWaiting.Count;

        for (int i = 0; i < lenght; i++)
        {
            carsWaiting.Dequeue().Stop = false;
        }
    }

    // We add the necessary logic to detect pedestrians as well as cars.
    protected override void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);

        //Pedestrians
        PedestrianAI currectPedestrian = other.gameObject?.GetComponent<PedestrianAI>();
        if (currectPedestrian != null)
        {
            pedestriansCrossing++;
        }
    }

    // We detect when a pedestrain leaves the crossing to decrease the counter.
    private void OnTriggerExit(Collider other)
    {
        if (other.isTrigger)
        {
            return;
        }

        PedestrianAI currectPedestrian = other.gameObject?.GetComponent<PedestrianAI>();
        if (currectPedestrian != null)
        {
            pedestriansCrossing--;
        }
    }

    // Redefines the condition to let the car leave the intersection.
    protected override bool CorrectConditions()
    {
        return pedestriansCrossing <= 0;
    }

    #endregion
}
