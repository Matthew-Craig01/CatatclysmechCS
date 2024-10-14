using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BuildingCells : MonoBehaviour
{
    private Dictionary<Vector2Int, GameObject> occupied;
    private HashSet<Vector2Int> cells;
    public Grass grass;
    public AstarPath astar;
    public Transform player;

    void Start()
    {
        occupied = new Dictionary<Vector2Int, GameObject>();
        var bigGrass = grass.tiles.Select(c => SnapToBigCell(c));
        var bigBorder = new HashSet<Vector2Int>(grass.border.Select(c => SnapToBigCell(c)));
        cells = new HashSet<Vector2Int>(bigGrass.Where(c => !bigBorder.Contains(c)));
    }

    void Update()
    {

    }

    //Make sure you call this whenever you create a new building
    public void Add(Vector2Int cell, GameObject building)
    {
        occupied.Add(SnapToBigCell(cell), building);
        astar.Scan();
    }

    //Make sure you call this (or the next function) whenever you destroy a building
    public void Remove(Vector2Int cell)
    {
        occupied.Remove(SnapToBigCell(cell));
    }

    public void Remove(Vector2 pos)
    {
        Remove(FromGlobalPosition(pos));
    }

    //Use this to check if the there is already a building on that square
    public bool IsOccupied(Vector2Int cell)
    {
        return occupied.ContainsKey(SnapToBigCell(cell));
    }

    public HashSet<Vector2Int> GetUnoccupiedSet()
    {
        return new HashSet<Vector2Int>(cells.Where(c => !occupied.ContainsKey(c)));
    }

    public Vector2Int[] GetUnoccupiedArray()
    {
        return cells.Where(c => !occupied.ContainsKey(c)).ToArray();
    }

    //Use this to check if you can place on a cell
    public bool IsValid(Vector2Int cell)
    {
        cell = SnapToBigCell(cell);
        var playerCell = FromGlobalPosition(player.position);
        float distance = Vector2.Distance(cell, playerCell);
        if (distance <= 5)
        {
            return false;
        }
        return cells.Contains(cell) && !occupied.ContainsKey(cell);
    }


    //Use this to check if you can place on a world position
    public bool IsValid(Vector2 pos)
    {
        var cell = FromGlobalPosition(pos);
        return IsValid(cell);
    }


    //Big Cell = 4 Cells
    //Buildings are only placed on big cells
    //Snap To Big cell -> Returns the cell rounded to the nearest big cell (still in cell units)
    public Vector2Int SnapToBigCell(Vector2Int cell)
    {
        var x = AxisToBigCell(cell.x, 4);
        var y = AxisToBigCell(cell.y, 4);
        var coords = new Vector2Int(x, y);
        return coords;
    }

    private int AxisToBigCell(float f, int cellSize)
    {
        return Mathf.RoundToInt(f / cellSize) * cellSize;
    }

    //Returns the cell in terms of the global position
    public Vector2 ToGlobalPosition(Vector2Int cell)
    {
        return grass.TileToWorld(cell);
    }

    //This returns the nearest big cell coords in the world
    public Vector2Int FromGlobalPosition(Vector2 pos)
    {
        var cell = grass.WorldToTile(pos);
        return SnapToBigCell(cell);
    }

    private void OnDrawGizmos()
    {
        if (cells == null)
        {
            return;
        }
        Gizmos.color = Color.green;
        var size = grass.tilemap.cellSize*4;
        foreach (var cell in GetUnoccupiedArray())
        {
            Gizmos.DrawWireCube(ToGlobalPosition(cell), size*0.8f);
        }
    }
}
