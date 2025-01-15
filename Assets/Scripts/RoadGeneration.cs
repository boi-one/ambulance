using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class RoadGeneration : MonoBehaviour
{
    public Tile roadTile;
    public Tile sidewalkTile;
    public Tilemap roadMap;
    public int streetAmount = 12;
    public int streetLength = 120;
    private Quaternion rotation = Quaternion.Euler(90, 90, 0);

    // Start is called before the first frame update
    void Start()
    {

        int stepSize = streetLength / streetAmount;
        for (int i = 0; i < streetAmount + 1; i++) //horizontal
        {
            CreateRoadHorizontal(new Vector3Int(-20, i * stepSize - stepSize * 2), new Vector3Int(6, streetLength));
        }

        for (int i = 0; i < streetAmount + 1; i++) //vertical
        {
            CreateRoadVertical(new Vector3Int(i * stepSize - stepSize * 2, -20), new Vector3Int(6, streetLength));
        }

    }

    // Update is called once per frame
    void Update()
    {

    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="start"></param>
    /// <param name="size">x: width y: height</param>
    public void CreateRoadHorizontal(Vector3Int start, Vector3Int size)
    {
        Vector3Int tilePosition = start;
        Tile tile;
        for (int i = 0; i < size.y; i++)
        {
            for (int j = 0; j <= size.x; j++)
            {
                if (j == 0 || j == size.x)
                    tile = sidewalkTile;
                else
                    tile = roadTile;

                if (roadMap.GetTile(roadMap.WorldToCell(tilePosition)) != roadTile)
                    roadMap.SetTile(tilePosition + new Vector3Int(0, j), tile);
            }
            tilePosition += new Vector3Int(1, 0);
        }
    }

    public void CreateRoadVertical(Vector3Int start, Vector3Int size)
    {
        Vector3Int tilePosition = start;
        Tile tile;
        for (int i = 0; i < size.y; i++)
        {
            for (int j = 0; j <= size.x; j++)
            {
                if (j == 0 || j == size.x)
                    tile = sidewalkTile;
                else
                    tile = roadTile;

                if (roadMap.GetTile(roadMap.WorldToCell(tilePosition)) != roadTile)
                    roadMap.SetTile(tilePosition + new Vector3Int(j, 0), tile);
                //TODO: houses and at the end of the streets a blockade check if the roadTile is bordering an empty tile
            }
            tilePosition += new Vector3Int(0, 1);
        }
    }
}
