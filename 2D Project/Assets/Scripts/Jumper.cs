using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumper : MonoBehaviour
{
    public float jumpForce;

    public Rigidbody2D rBody;

    public Vector3 jumpDirection;

    public GameObject jumpTarget;

    public float jumpWaitTime = 2f;
    float timer = 0f;

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= jumpWaitTime)
        {
            if (jumpTarget == null)
            {
                Jump();
            }
            else
            {
                Leap(jumpTarget.transform.position);
            }

            timer = 0f;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }

    void Jump()
    {
        //  Scale jump
        Vector3 jumpVect = jumpDirection * jumpForce;

        rBody.AddForce(jumpVect);
    }

    void Leap(Vector3 targetPosition)
    {
        Vector3 jumpVect = targetPosition - transform.position;
        
        jumpVect.Normalize();

        jumpVect *= jumpForce;

        rBody.AddForce(jumpVect);
    }
}
