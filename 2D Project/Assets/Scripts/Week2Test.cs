using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Week2Test : MonoBehaviour
{
    [SerializeField]
    Rigidbody2D ball;

    public Week2Test testing;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = ball.transform.position;
        transform.Translate(0, 0, -10f);

        ball.mass += 1f;
    }
}
