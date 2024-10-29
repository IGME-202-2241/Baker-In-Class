using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainManager : MonoBehaviour
{
    public TerrainData terrainData;

    [Range(0f, .1f)]
    public float perlinTimeStep;

    // Start is called before the first frame update
    void Start()
    {
        GenerateTerrain();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GenerateTerrain()
    {
        float[,] heightValues = new float[terrainData.heightmapResolution,terrainData.heightmapResolution];

        float xCoord = 0, yCoord = 0;

        for(int x = 0; x < terrainData.heightmapResolution; x++)
        {
            for (int y = 0; y < terrainData.heightmapResolution; y++)
            {
                heightValues[x, y] = Mathf.PerlinNoise(xCoord, yCoord);

                yCoord += perlinTimeStep;
            }

            xCoord += perlinTimeStep;
            yCoord = 0;
        }


        terrainData.SetHeights(0, 0, heightValues);
    }
}
