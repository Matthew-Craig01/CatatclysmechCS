using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Pathfinding;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Grass : MonoBehaviour
{
    public Tilemap tilemap;
    private LayerMask mask;
    public HashSet<Vector2Int> tiles {get; private set;} //tiles.Contains(gridPosition) => boolean which states whether on grass
    public HashSet<Vector2> tileWorld {get; private set;}
    public Vector2[] tileWorldList {get; private set;}
    public HashSet<Vector2Int> border {get; private set;}
    public HashSet<Vector2> borderWorld {get; private set;}
    public bool regenerate = true;

    void Start()
    {
        InitPathFinding();
        InitTiles();
    }

    private void InitPathFinding()
    {
        GridGraph gridGraph = AstarPath.active.data.gridGraph;

        for (int x = 0; x < gridGraph.width; x++)
        {
            for (int z = 0; z < gridGraph.depth; z++)
            {
                GraphNode node = gridGraph.GetNode(x, z);
                Vector3 pos = (Vector3)node.position;

                node.Walkable = Grass.CollidesWith(pos);
            }
        }

        AstarPath.active.Scan();
    }

    private void InitTiles()
    {
        if (!regenerate)
        {
            LoadTiles();
            return;
        }
        var box = tilemap.cellBounds;
        tiles = new HashSet<Vector2Int>();

        for (int x = box.xMin; x < box.xMax; x++)
        {
            for (int y = box.yMin; y < box.yMax; y++)
            {
                var pos = new Vector2Int(x, y);
                if (tilemap.HasTile(V2V3I(pos)))
                {
                    tiles.Add(pos);
                }
            }
        }
        SetBorder();
        tileWorld = TilesToWorld(tiles);
        //borderWorld = TilesToWorld(border);
        tileWorldList = new Vector2[tileWorld.Count];
        tileWorld.CopyTo(tileWorldList);
        SaveTiles();
    }

    private void SetBorder()
    {
        border = new HashSet<Vector2Int>();
        borderWorld = new HashSet<Vector2>();
        foreach (var tile in tiles)
        {
            var left = TilesContain(tile.x-1, tile.y);
            var downLeft = TilesContain(tile.x-1, tile.y-1);
            var upLeft = TilesContain(tile.x-1, tile.y+1);
            var right = TilesContain(tile.x+1, tile.y);
            var downRight = TilesContain(tile.x+1, tile.y-1);
            var upRight = TilesContain(tile.x+1, tile.y-1);
            var up = TilesContain(tile.x, tile.y+1);
            var down = TilesContain(tile.x, tile.y-1);
            var adjust = 1;

            var world = TileToWorld(tile);
            if (!left)
            {
                world.x -= adjust;
            }
            else if (!downLeft)
            {
                world.x -= adjust;
                world.y -= adjust;
            }
            else if (!upLeft)
            {
                world.x -= adjust;
                world.y += adjust;
            }
            else if(!right)
            {
                world.x += adjust;
            }
            else if (!downRight)
            {
                world.x += adjust;
                world.y -= adjust;
            }
            else if (!upRight)
            {
                world.x += adjust;
                world.y += adjust;
            }
            else if (!up)
            {
                world.y += adjust;
            }
            else if (!down)
            {
                world.y -= adjust;
            }
            else
            {
                continue;
            }
            border.Add(tile);
            borderWorld.Add(world);
        }
    }

    private void SaveTiles()
    {
        // public HashSet<Vector2Int> tiles {get; private set;}
        // public HashSet<Vector2> tileWorld {get; private set;}
        // public Vector2[] tileWorldList {get; private set;}
        // public HashSet<Vector2Int> border {get; private set;}
        // public HashSet<Vector2> borderWorld {get; private set;}
        Debug.Log("Saving Tiles");
        Save(tiles, "/tiles");
        Save(tileWorld, "/tileWorld");
        Save(border, "/border");
        Save(borderWorld, "/borderWorld");
    }

    private void Save(IEnumerable v2s, string path)
    {
        using (var writer = new StreamWriter("./Assets/Tilemaps" + path))
        {
            foreach (var v2 in v2s)
            {
                writer.WriteLine(v2);
            }
        }
    }

    private void LoadTiles()
    {
        // public HashSet<Vector2Int> tiles {get; private set;}
        // public HashSet<Vector2> tileWorld {get; private set;}
        // public Vector2[] tileWorldList {get; private set;}
        // public HashSet<Vector2Int> border {get; private set;}
        // public HashSet<Vector2> borderWorld {get; private set;}
        tiles = FileToHashSetV2I("/tiles");
        tileWorld = FileToHashSetV2("/tileWorld");
        tileWorldList = new Vector2[tileWorld.Count];
        tileWorld.CopyTo(tileWorldList);
        border = FileToHashSetV2I("/border");
        borderWorld = FileToHashSetV2("/borderWorld");
    }

    private HashSet<Vector2> FileToHashSetV2(string path)
    {
        var hset = new HashSet<Vector2>();
        using (var reader = new StreamReader("./Assets/Tilemaps" + path))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                hset.Add(ParseLineV2(line));
            }
        }
        return hset;
    }

    private HashSet<Vector2Int> FileToHashSetV2I(string path)
    {
        var hset = new HashSet<Vector2Int>();
        using (var reader = new StreamReader("./Assets/Tilemaps" + path))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                hset.Add(ParseLineV2I(line));
            }
        }
        return hset;
    }

    private Vector2 ParseLineV2(string line)
    {
        line = line[1..^1];
        var split = line.Split(", ");
        return new Vector2(float.Parse(split[0]), float.Parse(split[1]));
    }

    private Vector2Int ParseLineV2I(string line)
    {
        line = line[1..^1];
        var split = line.Split(", ");
        return new Vector2Int(int.Parse(split[0]), int.Parse(split[1]));
    }

    public bool TilesContain(int x, int y)
    {
        return tiles.Contains(new Vector2Int(x, y));
    }

    private Vector3Int V2V3I(Vector2Int v2)
    {
        return new Vector3Int(v2.x, v2.y, -1);
    }

    private HashSet<Vector2> TilesToWorld(HashSet<Vector2Int> tiles)
    {
        var world = new HashSet<Vector2>();
        foreach (var tile in tiles)
        {
            world.Add(TileToWorld(tile));
        }
        return world;
    }

    public Vector2 TileToWorld(Vector2Int tile)
    {
        return tilemap.GetCellCenterWorld(V2V3I(tile));
    }

    //Use this function with cursor position to get grid cell position
    public Vector2Int WorldToTile(Vector2 pos)
    {
        return (Vector2Int)tilemap.WorldToCell((pos));
    }

    public bool CollidesWithBorder(Vector2 pos)
    {
        var cell = WorldToTile(pos);
        for (int x = -1; x <= 1; x++) {
            for (int y = -1; y <= 1; y++) {
                var check = new Vector2Int(cell.x + x, cell.y + y);
                if (border.Contains(check))
                {
                    return true;
                }
            }
        }
        return false;
        // //TODO Improve efficiency
        // foreach (var tile in borderWorld)
        // {
        //     var collision = Vector2.Distance(position, tile) <= distance;
        //     if (collision)
        //     {
        //         return true;
        //     }
        // }
        // return false;
    }


    //Reudementary check
    public static bool CollidesWith(Vector2 position)
    {
        return Physics2D.OverlapPoint(position, LayerMask.GetMask("Grass"));
    }

    public static Vector2 SnapToGrid(Vector2 position)
    {
        var cell = 2f;
        float x = SnapToGrid(position.x, cell);
        float y = SnapToGrid(position.y, cell);
        return new Vector2(x, y);
    }


    private static float SnapToGrid(float f, float cell)
    {
        return Mathf.Round(f / cell) * cell;
    }
}
