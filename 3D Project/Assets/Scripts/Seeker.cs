using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Seeker : Agent
{
    public GameObject target;

    Vector3 seekForce;
    public float seekScalar;

    public Vector3 worldBounds;
    Vector3 boundsForce;
    public float boundsScalar = 1f;

    protected override Vector3 CalcSteering()
    {
        seekForce = Seek(target) * seekScalar;

        //  Check for in of bounds
        // if yes seek(vetor.zero)
        if (transform.position.x < worldBounds.x / 2f &&
            transform.position.x > worldBounds.x / -2f &&
            transform.position.z < worldBounds.z / 2f &&
            transform.position.z > worldBounds.z / -2f)
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
        Gizmos.color = Color.green;
        Gizmos.DrawRay(transform.position, velocity);

        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, seekForce);

        //
        //  Bounds
        //
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(Vector3.zero, worldBounds);

        Gizmos.color = Color.magenta;
        Gizmos.DrawRay(transform.position, boundsForce);
    }
}
