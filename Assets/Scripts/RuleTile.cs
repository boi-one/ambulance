using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class RuleTile
{
    public Tile up;
    public Tile down;
    public Tile left;
    public Tile right;

    public Tilemap tilemap;
    public Dictionary<Vector3Int, Tile> ruleTiles = new Dictionary<Vector3Int, Tile>();

    public RuleTile(Tile up, Tile down, Tile left, Tile right, Tilemap tilemap)
    {
        this.up = up;
        this.down = down;
        this.left = left;
        this.right = right;
        this.tilemap = tilemap;

        ruleTiles.Add(new Vector3Int(0, 1), up);
        ruleTiles.Add(new Vector3Int(0, -1), down);
        ruleTiles.Add(new Vector3Int(-1, 0), left);
        ruleTiles.Add(new Vector3Int(1, 0), right);
    }

    public void SetTile(Vector3Int position, Tile checkTile)
    {
        foreach(KeyValuePair<Vector3Int, Tile> pair in  ruleTiles)
        {
            if(tilemap.GetTile(position + pair.Key) == checkTile)
                tilemap.SetTile(position, pair.Value);
        }
    }
}
