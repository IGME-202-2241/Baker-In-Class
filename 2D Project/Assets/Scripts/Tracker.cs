using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Tracker : MonoBehaviour
{
    public bool isFiring = false;

    //  Old polling system
    bool isKeyDown = false;
    int fireKey = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isFiring)
        {
            Debug.Log("Fire!");
        }

        // old
        if (Input.GetMouseButtonDown(fireKey))
        {
            if (!isKeyDown)
            {
                Debug.Log("Poll Fire");
            }


            isKeyDown = true;
        }
        else
        {
            isKeyDown = false;
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
