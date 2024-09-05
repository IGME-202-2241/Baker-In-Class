using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject spawnPrefab;

    // Start is called before the first frame update
    void Start()
    {
        /*for (int i = 0; i < 100; i++)
        {
            GameObject newThing = Instantiate(spawnPrefab, transform.position, Quaternion.identity);

            newThing.transform.position = Vector3.zero;

            //newThing.GetComponent<Week2Demo>().gameObject.SetActive(false);
        }*/
        GameObject newThing = Instantiate(spawnPrefab, transform.position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
