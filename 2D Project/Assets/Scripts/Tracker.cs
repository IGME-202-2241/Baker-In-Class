using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


//  Look at and move to the mouse
public class Tracker : MonoBehaviour
{
    public bool isFiring = false;

    public Vector3 mousePos;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isFiring)
        {
            //Debug.Log("Fire");

            mousePos = Mouse.current.position.ReadValue();

            mousePos = Camera.main.ScreenToWorldPoint(mousePos);

            mousePos.z = transform.position.z;

            transform.position = mousePos;
        }
    }


    public void OnFire(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started ||
            context.phase == InputActionPhase.Performed)
        {
            
            isFiring = true;
        }
        else
        {
            isFiring = false;
        }
    }
}
