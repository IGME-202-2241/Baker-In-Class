using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Vehicle : MonoBehaviour
{
    // Reference to RigidBody on this GameObject
    public Rigidbody rBody;

    // Fields for Speed
    public float maxSpeed, minSpeed;

    // Fields for Acceleration/Deceleration
    public float accelerationRate, decelerationRate;

    // Fields for Turning
    public float turnSpeed;

    // Fields for Input
    public Vector3 movementDirection;

    // Fields for Movement Vectors
    Vector3 velocity, acceleration;

    // Fields for Quaternions
    Quaternion turning;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        

        
    }

    private void FixedUpdate()
    {
        acceleration = Vector3.zero;

        if (movementDirection.z != 0)
        {
            acceleration = transform.forward * (movementDirection.z * accelerationRate);

            velocity += acceleration * Time.fixedDeltaTime;

            velocity = Vector3.ClampMagnitude(velocity, maxSpeed);
        }
        else
        {
            velocity *= 1f - (decelerationRate * Time.fixedDeltaTime);

            //  Stop the vehicle when it reaches a certain speed
            if (velocity.magnitude < minSpeed)
            {
                velocity = Vector3.zero;
            }
        }

        //transform.position = velocity;
        

        //  Rotation Stuff
        turning = Quaternion.Euler(0f, movementDirection.x * turnSpeed * Time.fixedDeltaTime, 0f);

        //velocity *= turning;
        velocity = turning * velocity;

        //rBody.MoveRotation(transform.rotation * turning);
        //rBody.MovePosition(transform.position + velocity * Time.fixedDeltaTime);
        rBody.Move(transform.position + velocity * Time.fixedDeltaTime, transform.rotation * turning);
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        movementDirection = context.ReadValue<Vector2>();

        movementDirection.z = movementDirection.y;
        movementDirection.y = 0;
    }
}
