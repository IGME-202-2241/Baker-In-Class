using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.PlayerLoop;

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

    private void Update()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        acceleration = Vector3.zero;

        //  Vehcile moving faster
        if (movementDirection.z != 0f)
        {
            acceleration = transform.forward * (movementDirection.z * accelerationRate * Time.fixedDeltaTime);

            velocity += acceleration * Time.fixedDeltaTime;

            velocity = Vector3.ClampMagnitude(velocity, maxSpeed);
        }
        // Vehcilce slowing down
        else
        {
            velocity *= 1f - (decelerationRate * Time.fixedDeltaTime);

            //  Stop the vehicle when it reaches a certain speed
            if (velocity.magnitude < minSpeed)
            {
                velocity = Vector3.zero;
            }

        }

        

        //  Rotation stuff
        turning = Quaternion.Euler(0f, movementDirection.x * turnSpeed * Time.fixedDeltaTime, 0f);

        //velocity *= turning;
        velocity = turning * velocity;

        //rBody.MovePosition(transform.position + velocity);
        //rBody.MoveRotation(transform.rotation * turning);
        rBody.Move(transform.position + velocity, transform.rotation * turning);
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        movementDirection = context.ReadValue<Vector2>();

        movementDirection.z = movementDirection.y;

        movementDirection.y = 0;
    }
}
