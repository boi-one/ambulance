using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Road
{
    public Vector3 position;
    public Vector3 start;
    public Vector3 end;

    public Road(Vector3 position, int length = 10)
    {
        this.position = position;
        start = position - (position * 0.5f);
        end = position + (position * 0.5f);
    }
}

public class RoadGeneration : MonoBehaviour
{
    public Tile roadTile;
    public Tilemap roadMap;
    public List<Road> roads = new List<Road>();

    // Start is called before the first frame update
    void Start()
    {
        roads.Add(new Road(new Vector3(0, 0, 0)));
        foreach(Road road in roads)
        {
            for(int i = 0; i < (road.start - road.end).magnitude; i++)
            {
                //roadMap.SetTile(roadTile, //tile position) TODO: FIX DIT
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
