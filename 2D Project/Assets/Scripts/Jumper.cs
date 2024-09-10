using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumper : MonoBehaviour
{
    public Rigidbody2D rBody;

    public float jumpForce;

    public Vector3 jumpDirection;

    public GameObject jumpTarget;

    public float jumpWaitTime = 2f;
    float timer = 0;

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer > jumpWaitTime)
        {
            //Jump();

            Leap(jumpTarget.transform.position);

            timer = 0;
        }
        
    }

    void Jump()
    {
        Vector3 jumpVect = jumpDirection * jumpForce;

        rBody.AddForce(jumpVect);
    }

    void Leap(Vector3 targetPos)
    {
        // transform.postion
        Vector3 jumpVect = targetPos - transform.position;

        jumpVect.Normalize();

        jumpVect *= jumpForce;

        rBody.AddForce(jumpVect);
    }
}
