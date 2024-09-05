using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Week2Demo : MonoBehaviour
{

    [SerializeField]
    private int favNum = 5;

    public Rigidbody2D ball;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(ball.transform.position);

        //ball.transform.Translate(1, 1, 1);

        ball.mass += 1f;

        Vector3 neVect = ball.transform.position;

        neVect.z = transform.position.z;
    }
}
