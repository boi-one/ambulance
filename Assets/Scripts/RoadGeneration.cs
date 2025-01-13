using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Road
{
    public Vector3Int start;
    public Vector3Int direction;
    public int length;
    public int width;
    public Road(Vector3Int start, Vector3Int direction, int length = 10, int width = 3)
    {
        this.start = start;
        this.direction = direction;
        this.length = length;
        this.width = width;
    }
}

public class RoadGeneration : MonoBehaviour
{
    public Tile roadTile;
    public Tilemap roadMap;
    public List<Road> roads = new List<Road>();
    private Quaternion rotation = Quaternion.Euler(90, 90, 0);

    // Start is called before the first frame update
    void Start()
    {
        Road road = new Road(new Vector3Int(0, 0, 0), new Vector3Int(0, 1, 0), 20);

        Vector3Int tilePosition = road.start;
        for (int i = 0; i < road.length; i++)
        {
            for (int j = 0; j < road.width; j++)
            {
                roadMap.SetTile(tilePosition + new Vector3Int(j, 0), roadTile);

            }
            tilePosition += road.direction;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
