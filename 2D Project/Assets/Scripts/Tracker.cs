using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Tracker : MonoBehaviour
{
    public bool isFiring = false;

    public Vector3 mousePosition;

    // Update is called once per frame
    void Update()
    {
        mousePosition = Mouse.current.position.ReadValue();

        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        mousePosition.z = transform.position.z;

        if (isFiring)
        {
            Debug.Log("Fire!");

            transform.position = mousePosition;
        }
        else
        {
            Vector3 targetPos = mousePosition - transform.position;

            float targetSpin = Mathf.Atan2(targetPos.y, targetPos.x);

            targetSpin *= Mathf.Rad2Deg;

            Quaternion turnRotation = Quaternion.Euler(0, 0, targetSpin);

            transform.rotation = turnRotation;
        }
    }

    public void OnFire(InputAction.CallbackContext context)
    {
        //  On Press
        if (context.phase == InputActionPhase.Started)
        {
            isFiring = true;
        }
        //  On Release
        else if(context.phase == InputActionPhase.Canceled)
        {
            isFiring = false;
        }
    }
}
