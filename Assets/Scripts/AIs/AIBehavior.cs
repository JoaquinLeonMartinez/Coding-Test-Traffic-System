using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/*
 * Parent class of all Artificial Intelligences.
 */
public abstract class AIBehavior : MonoBehaviour
{
    #region Attributes

    // List of points on the scene defining the path. In future extensions this should be automated, right now it has to be done from the editor.
    [SerializeField]
    protected List<Transform> wayPoints = null;

    // Determine the minimum distance to approach the next point.
    [SerializeField]
    protected float arriveDistance = 0.6f;

    // Rotation angle offset.
    [SerializeField]
    protected float turningAngleOffset = 5;

    // Determines if the path is cyclic or not.
    [SerializeField]
    protected bool isLoop = true;

    // Current way point.
    protected Vector3 currentTargetPosition;

    // Current postion in the list of waypoints.
    protected int index = 0;

    // Determines whether the vehicle is stop or not
    private bool stop;

    public bool Stop
    {
        get { return stop; }
        set { stop = value; }
    }

    // This event will invoke the corresponding controller.
    [field: SerializeField]
    public UnityEvent<Vector2> OnAction { get; set; }

    #endregion

    #region Methods
    void Start()
    {
        SetPath();
    }

    private void Update()
    {
        CheckIfArrived();
        Action();
    }

    // Initialize all necessary variables and start with the behavior.
    public void SetPath()
    {
        if (wayPoints.Count == 0)
        {
            // If you do not have waypoints we cannot start the behavior.
            Destroy(this.gameObject);
            return;
        }

        this.index = 0;
        currentTargetPosition = this.wayPoints[index].position;

        Vector3 relativePoint = transform.InverseTransformPoint(this.wayPoints[index + 1].position);

        // Look towards the waypoint
        float angle = Mathf.Atan2(relativePoint.x, relativePoint.z) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0, angle, 0);

        // Start
        Stop = false;
    }

    // In our case the action will be walk or drive (depends of de case)
    private void Action()
    {
        if (Stop)
        {
            // If we are stop our speed will be 0,0
            OnAction?.Invoke(Vector2.zero);
        }
        else
        {
            // If not, we have to calculate the direction

            Vector3 relativePoint = transform.InverseTransformPoint(currentTargetPosition);

            float angle = Mathf.Atan2(relativePoint.x, relativePoint.z) * Mathf.Rad2Deg;

            int rotate = 0;

            if (angle > turningAngleOffset)
            {
                rotate = 1;
            }
            else if (angle < -turningAngleOffset)
            {
                rotate = -1;
            }

            OnAction?.Invoke(new Vector2(rotate, 1));
        }
    }

    // Check the distance between itself and the next point.
    private void CheckIfArrived()
    {
        if (!Stop)
        {
            var distanceToCheck = arriveDistance;

            if (Vector3.Distance(currentTargetPosition, transform.position) < distanceToCheck)
            {
                SetNextTargetIndex();
            }
        }
    }

    // Determines the next waypoint to be followed
    private void SetNextTargetIndex()
    {
        index++;
        if (index >= wayPoints.Count && !isLoop)
        {
            Stop = true;
            Destroy(this.gameObject);
        }
        else if (index >= wayPoints.Count)
        {
            // In this case, we are in the last waypoint but we have to start again.
            index = 0;
            currentTargetPosition = wayPoints[index].position;
        }
        else
        {
            // In this case, we have to continue with the next waypoint.
            currentTargetPosition = wayPoints[index].position;
        }
    }
    #endregion
}
