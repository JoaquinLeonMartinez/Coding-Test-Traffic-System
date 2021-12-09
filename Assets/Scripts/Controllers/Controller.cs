using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Parent class of all Controllers.
 */
public abstract class Controller : MonoBehaviour
{
    // Rigidbody reference indicated in the editor, we could replace it with a GetComponent<RigidBody> in the Start method.
    [SerializeField]
    private Rigidbody rb;

    // Vehicle power.
    [SerializeField]
    private float power;

    // Vehicle max speed.
    [SerializeField]
    private float maxSpeed;

    // Vehicle torque.
    [SerializeField]
    private float torque;

    // Determines the direction of movement.
    [SerializeField]
    private Vector2 movement;

    // This method will be invoke to modify the movement direction
    public void Move(Vector2 input)
    {
        this.movement = input;
    }

    // We use the fixed update to add force and torque to the rigidbody.
    private void FixedUpdate()
    {
        if (rb.velocity.magnitude < maxSpeed)
        {
            rb.AddForce(movement.y * transform.forward * power);
        }

        rb.AddTorque(movement.x * Vector3.up * torque * movement.y);
    }
}
