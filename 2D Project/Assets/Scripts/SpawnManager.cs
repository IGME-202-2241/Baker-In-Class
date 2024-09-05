using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject spawnPrefab;

    public Vector3 spawnPosition;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 10; i++)
        {
            Instantiate(spawnPrefab);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
