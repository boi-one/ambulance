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
            CreateRoadHorizontal(new Vector3Int(0, i * stepSize), new Vector3Int(6, streetLength));
        }

        for (int i = 0; i < streetAmount; i++) //vertical
        {
            CreateRoadVertical(new Vector3Int(i * stepSize, 0), new Vector3Int(6, streetLength));
        }

        for(int x = 0; x < streetLength; x++)
        {
            for(int y = 0; y < streetLength; y++)
            {
                if (roadMap.GetTile(roadMap.WorldToCell(new Vector3Int(x, y))) == roadTile)
                    CheckAroundTile3(new Vector3Int(x, y), blockadeTile);
            }
        }
        for(int x = 0; x < streetLength; x++)
        {
            for(int y = 0; y < streetLength; y++)
                if (roadMap.GetTile(roadMap.WorldToCell(new Vector3Int(x, y))) == sidewalkTile)
                    CheckAroundTile1(new Vector3Int(x, y), houseTile);
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

    public void CheckAroundTile3(Vector3Int position, Tile tile)
    {
        for (int i = position.x - 1; i < position.x + 2; i++)
        {
            for (int j = position.y - 1; j < position.y + 2; j++)
            {
                if (roadMap.GetTile(roadMap.WorldToCell(new Vector3Int(i, j))) == null)
                    collisionMap.SetTile(new Vector3Int(i, j), tile);
            }
        }
    }
    public void CheckAroundTile1(Vector3Int position, Tile tile)
    {
        Vector3Int[] positions =
        {
            new Vector3Int(position.x - 1, position.y),
            new Vector3Int(position.x + 1, position.y),
            new Vector3Int(position.x, position.y -1),
            new Vector3Int(position.x, position.y + 1),
        };

        for (int i = 0; i < positions.Length; i++)
        {
            if (roadMap.GetTile(roadMap.WorldToCell(positions[i])) == null)
                collisionMap.SetTile(positions[i], tile);
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
            }
            tilePosition += new Vector3Int(0, 1);
        }
    }
}
