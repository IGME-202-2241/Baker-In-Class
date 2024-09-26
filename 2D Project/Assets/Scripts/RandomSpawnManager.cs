using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class RandomSpawnManager : MonoBehaviour
{
    public List<SpriteRenderer> spritePrefabs = new List<SpriteRenderer>();

    public List<GameObject> spawnObjects = new List<GameObject>();

    public List<Color> spawnColors = new List<Color>();

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

        spawnObjects.Add(newSprite.gameObject);
    }

    SpriteRenderer PickRandomObject()
    {
        float randValue = Random.Range(0f, 1f);

        if(randValue < .1f)                 // 10%
        {
            return spritePrefabs[0];
        }
        else if(randValue < .6f)            // 50% 
        {
            return spritePrefabs[1];
        }
        else
        {
            return spritePrefabs[2];
        }
    }

    public void OnFire(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            //  Despawn Stuff
            foreach (GameObject obj in spawnObjects)
            {
                Destroy(obj);
            }

            spawnObjects.Clear();
        }
    }
}
