using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seeker : Agent
{
    public GameObject target;

    public float seekScalar = 4f;
    Vector3 seekForce = Vector3.zero;

    public Vector3 bounds = Vector3.zero;
    Vector3 boundsForce = Vector3.zero;

    protected override Vector3 CalcSteering()
    {
        seekForce = Seek(target) * seekScalar;

        //  Check for out of bounds
        // if yes seek(vetor.zero)
        if (transform.position.x < bounds.x / 2f &&
            transform.position.x > bounds.x / -2f &&
            transform.position.z < bounds.z / 2f &&
            transform.position.z > bounds.z / -2f)
        {
            boundsForce = Vector3.zero;
        }
        else
        {
            boundsForce = Seek(Vector3.zero);
            
        }

        return seekForce + boundsForce;
    }

    private void OnDrawGizmos()
    {
        //
        //  Velocity
        //
        Gizmos.color = Color.green;
        Gizmos.DrawRay(transform.position, velocity);

        //  Line to target
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, target.transform.position);

        // Show bounds
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(Vector3.zero, bounds);

        //  Show bounds force
        Gizmos.color = Color.magenta;
        Gizmos.DrawRay(transform.position, boundsForce);
    }
}
