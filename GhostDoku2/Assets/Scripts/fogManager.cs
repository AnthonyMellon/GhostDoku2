using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fogManager : MonoBehaviour
{
    public GameObject fogTile;

    public float tileWidth;
    public float tileHeight;

    //Eventually moved to map manager script
    public float mapWidth;
    public float mapHeight;

    // Start is called before the first frame update
    void Start()
    {
        spawnFog();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void spawnFog()
    {
        float nTilesX = mapWidth / tileWidth;
        float nTilesY = mapHeight / tileHeight;

        for(int x = 0; x < nTilesX; x++)
        {
            for(int y = 0; y < nTilesY; y++)
            {
                float xPos = x - (nTilesX / 2);
                xPos *= tileWidth;

                float yPos = y - (nTilesY / 2);
                yPos *= tileHeight;

                GameObject currentTile = Instantiate(fogTile, new Vector3(xPos, yPos, 0), new Quaternion(), transform);
                currentTile.transform.localScale = new Vector3(tileWidth, tileHeight, 0);
            }
        }
    }
}
