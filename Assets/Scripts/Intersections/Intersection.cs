using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Class in charge of the intersections logic.
 * The cars will start in the same order in which they arrived.
 */
public abstract class Intersection : MonoBehaviour
{
    #region Attributes

    // Queue of cars waiting to enter in the intersection.
    [SerializeField]
    protected Queue<CarAI> carsWaiting;

    // Waiting time in each traffic sign
    [SerializeField]
    protected float waitingTime;

    #endregion

    #region Methods

    private void Start()
    {
        carsWaiting = new Queue<CarAI>();
    }

    protected virtual void OnTriggerEnter(Collider other)
    {
        // We just want to detect the collision with the sphere collider, not the trigger.
        if (other.isTrigger)
        {
            return;
        }

        // If it is a Car we enqueue it
        CarAI currentCar = other.gameObject?.GetComponent<CarAI>();
        if (currentCar != null)
        {
            currentCar.Stop = true;
            carsWaiting.Enqueue(currentCar);

            //Notify that there are a car waiting
            StartCoroutine(CheckWaitingCarStatus());
        }
    }

    IEnumerator CheckWaitingCarStatus()
    {
        // Wait "waitingTime" seconds and then check if it can come out, once it comes out we wait again for "waitingTime" seconds to check the next one.
        if (carsWaiting.Count > 1)
        {
            yield return null; // It means there are another thread, so we don not need this one.
        }
        else
        {
            while (carsWaiting.Count > 0)
            {
                yield return new WaitForSeconds(waitingTime);

                // Before the action we have to check if there are any other condition.
                while (!CorrectConditions())
                {
                    yield return null;
                }

                // Once the intersection has been cleared we will carry out our action.
                Action();
            }
        }
    }

    // Virtual method for defining the conditions, may change depending on the type of intersection.
    protected virtual bool CorrectConditions()
    {
        return true;
    }

    // Virtual method that defines the action to be performed in your turn.
    protected virtual void Action()
    {
        // By default, the action will continue with the predefined path.
        carsWaiting.Dequeue().Stop = false;
    }

    #endregion
}
