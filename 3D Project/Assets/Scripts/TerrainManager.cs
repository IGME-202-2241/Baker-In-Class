using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainManager : MonoBehaviour
{
    public Terrain terrain;

    [Range(0f, 0.1f)]
    public float perlinStepValue;

    // Start is called before the first frame update
    void Start()
    {
        //GenerateTerrain();
    }

    // Update is called once per frame
    void Update()
    {
        GenerateTerrain();
    }

    public void GenerateTerrain()
    {
        float[,] heightValues = new float[terrain.terrainData.heightmapResolution, terrain.terrainData.heightmapResolution];

        float xCoord = 0, yCoord = 0;

        for (int x = 0; x < terrain.terrainData.heightmapResolution; x++)
        {
            for (int y = 0; y < terrain.terrainData.heightmapResolution; y++)
            {
                heightValues[x, y] = Mathf.PerlinNoise(xCoord, yCoord);

                yCoord += perlinStepValue;
            }

            xCoord += perlinStepValue;
            yCoord = 0;
        }

        terrain.terrainData.SetHeights(0, 0, heightValues);
    }
}
