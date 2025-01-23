using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class RoadGeneration : MonoBehaviour
{
    public Tile roadTile;
    public Tile sidewalkTile;
    public Tile blockadeTile;
    public Tile houseTile;
    public Tilemap roadMap;
    public Tilemap collisionMap;
    public int streetAmount = 12;
    public int streetLength = 120;
    private Quaternion rotation = Quaternion.Euler(90, 90, 0);
    private List<Tile> allTiles = new List<Tile>();

    // Start is called before the first frame update
    void Start()
    {

        int stepSize = streetLength / streetAmount;
        for (int i = 0; i < streetAmount; i++) //horizontal
        {
            CreateRoadHorizontal(new Vector3Int(-20, -20 + i * stepSize - stepSize * 2), new Vector3Int(6, streetLength));
        }

        for (int i = 0; i < streetAmount; i++) //vertical
        {
            CreateRoadVertical(new Vector3Int(-20 + i * stepSize - stepSize * 2, -20), new Vector3Int(6, streetLength));
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

    public void CheckAroundTile(Vector3Int position)
    {
        for (int i = position.x - 1; i < position.x + 2; i++)
        {
            for (int j = position.y - 1; j < position.y + 2; j++)
            {
                //if (roadMap.GetTile(roadMap.WorldToCell(new Vector3Int(i, j))) == null)
                //    collisionMap.SetTile(new Vector3Int(i, j), blockadeTile);
                //if (roadMap.GetTile(roadMap.WorldToCell(new Vector3Int(i, j))) == sidewalkTile | houseTile)
                //    collisionMap.SetTile(new Vector3Int(i, j), houseTile);
            }
        }
    }
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
                else
                {
                    CheckAroundTile(tilePosition);
                }
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
                {
                    roadMap.SetTile(tilePosition + new Vector3Int(j, 0), tile);
                }
                else
                {
                    CheckAroundTile(tilePosition);
                }
                
            }
            tilePosition += new Vector3Int(0, 1);
        }
    }
}
