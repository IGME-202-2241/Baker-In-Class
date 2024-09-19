using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Tracker : MonoBehaviour
{
    public bool isFiring = false;

    // Update is called once per frame
    void Update()
    {
        if(isFiring)
        {
            Debug.Log("Fire!");
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
