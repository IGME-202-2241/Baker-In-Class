using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


//  Look at and move to the mouse
public class Tracker : MonoBehaviour
{
    public bool isMoving = false;

    public Vector2 mousePos;

    // Update is called once per frame
    void Update()
    {
        mousePos = Mouse.current.position.ReadValue();

        mousePos = Camera.main.ScreenToWorldPoint(mousePos);

        //mousePos.z = transform.position.z;

        if (isMoving)
        {
            //Debug.Log("Fire");
            transform.position = mousePos;
        }
        else
        {
            Vector2 targetPos = mousePos;//(Vector3)mousePos - transform.position;

            float targetAngle = Mathf.Atan2(targetPos.y, targetPos.x);

            targetAngle *= Mathf.Rad2Deg;

            Quaternion lookRotation = Quaternion.Euler(0, 0, targetAngle);

            transform.rotation = lookRotation;
        }
    }


    public void OnFire(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started ||
            context.phase == InputActionPhase.Performed)
        {
            
            isMoving = true;
        }
        else
        {
            isMoving = false;
        }
    }
}
