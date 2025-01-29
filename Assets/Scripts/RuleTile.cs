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
    public Tile cornerLeft;
    public Tile cornerRight;
    public Tile cornerTopLeft;
    public Tile cornerTopRight;

    public Tilemap setMap;
    public Tilemap checkMap;
    public Dictionary<Vector3Int, Tile> ruleTiles = new Dictionary<Vector3Int, Tile>();
    public Dictionary<Vector3Int, Tile> ruleCornerTiles = new Dictionary<Vector3Int, Tile>();

    public int test;

    public RuleTile(Tile up, Tile down, Tile left, Tile right, Tile cLeft, Tile cRight, Tile cTRight, Tile cTLeft, Tilemap checkMap, Tilemap setMap)
    {
        this.up = up;
        this.down = down;
        this.left = left;
        this.right = right;
        this.checkMap = checkMap;
        this.setMap = setMap;

        ruleTiles.Add(new Vector3Int(0, 1), up);
        ruleTiles.Add(new Vector3Int(0, -1), down);
        ruleTiles.Add(new Vector3Int(-1, 0), left);
        ruleTiles.Add(new Vector3Int(1, 0), right);

        ruleCornerTiles.Add(new Vector3Int(-1, -1), cornerLeft);
        ruleCornerTiles.Add(new Vector3Int(1, -1), cornerRight);
        ruleCornerTiles.Add(new Vector3Int(1, 1), cornerTopRight);
        ruleCornerTiles.Add(new Vector3Int(-1, 1), cornerTopLeft);
    }

    public void SetTile(Vector3Int position, Tile checkTile)
    {
        foreach (KeyValuePair<Vector3Int, Tile> pair in ruleTiles)
        {
            if (checkMap.GetTile(position) == null && checkMap.GetTile(position + pair.Key) == checkTile)
            {
                setMap.SetTile(position, pair.Value);
            }
        }
    }

    public void SetCornerTile(Vector3Int position, Tile checkTile)
    {
        foreach(KeyValuePair<Vector3Int, Tile> pair in ruleCornerTiles)
        {
            if(ruleTiles.ContainsValue(setMap.GetTile<Tile>(position + new Vector3Int(pair.Key.x, 0))) && ruleTiles.ContainsValue(setMap.GetTile<Tile>(position + new Vector3Int(0, pair.Key.y))))
            {
                setMap.SetTile(position, pair.Value);
            }
        }
    }
}
