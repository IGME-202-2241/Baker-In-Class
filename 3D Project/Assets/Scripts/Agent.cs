using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Agent : MonoBehaviour
{
    // Reference to RigidBody on this GameObject
    public Rigidbody rBody;

    // Fields for Speed
    public float maxSpeed, maxForce;

    // Fields for Movement Vectors
    protected Vector3 velocity, acceleration;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        // Setup
        Quaternion nextRotation = transform.rotation;
        Vector3 nextPosition = transform.position;

        // Start with acceleration based on the steering force
        acceleration = CalcSteering();

        //  Limit how much force an Agent can feel
        acceleration = Vector3.ClampMagnitude(acceleration, maxForce);

        // Calc velocity based on accel scaled by time
        velocity += acceleration * Time.fixedDeltaTime;

        // Clamp velocity to min/max speed
        velocity = Vector3.ClampMagnitude(velocity, maxSpeed);

        // Rotate to face the direction of travel
        nextRotation = Quaternion.LookRotation(velocity, Vector3.up);

        //  Use velocity to calc next position
        nextPosition += (velocity * Time.fixedDeltaTime);

        //  Move the agent
        rBody.Move(nextPosition, nextRotation);

        // Zero out acceleration (b/c it's only a field for debugging)
        acceleration = Vector3.zero;
    }

    protected abstract Vector3 CalcSteering();

    protected Vector3 Seek(Vector3 targetPos)
    {
        // Calculate desired velocity
        Vector3 desiredVelocity = targetPos - transform.position;

        desiredVelocity = desiredVelocity.normalized * maxSpeed;

        // Calculate & return seek steering force
        return desiredVelocity - velocity;
    }

    protected Vector3 Seek(GameObject target)
    {
        return Seek(target.transform.position);
    }
}
