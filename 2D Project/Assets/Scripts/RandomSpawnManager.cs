using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class RandomSpawnManager : MonoBehaviour
{
    public List<SpriteRenderer> spritePrefabs = new List<SpriteRenderer>();

    public List<GameObject> spawnedObjects = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        Spawn();
    }

    // Update is called once per frame
    void Update()
    {
        Spawn();
    }

    public void Spawn()
    {
        SpriteRenderer newSprite = Instantiate(PickRandomObject());

        spawnedObjects.Add(newSprite.gameObject);
    }

    SpriteRenderer PickRandomObject()
    {
        float randValue = Random.Range(0f, 100f);

        Random.Range(0, 3);

        if (randValue < 5f)
        {
            //  Bucket 1    20%
            return spritePrefabs[0];
        }
        else if (randValue < 65f)
        {
            return spritePrefabs[1];
        }
        else
        {
            return spritePrefabs[2];
        }
    }

    public void OnFire(InputAction.CallbackContext callback)
    {
        if (callback.phase == InputActionPhase.Performed)
        {
            foreach (GameObject obj in spawnedObjects)
            {
                Destroy(obj);
            }

            spawnedObjects.Clear();
        }
    }
}
