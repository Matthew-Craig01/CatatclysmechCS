using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SolarPanelSpawner : MonoBehaviour
{
    public GameObject solarPanel;
    public GameObject tracker;
    public BuildingCells cells;
    public int solarPanelCount {get; private set;}
    public int maxSolarPanels;

    void Start()
    {

    }

    void Update()
    {

    }

    public void Spawn()
    {
        if (solarPanelCount == 0)
        {
            var x = RandomPos();
            var y = RandomPos();
            var world = new Vector2(x, y);
            var cell = cells.FromGlobalPosition(world);
            CreateGO(cell, cells.ToGlobalPosition(cell));
            return;
        }
        if (solarPanelCount < maxSolarPanels){
            var open = cells.GetUnoccupiedArray();
            var random = Random.Range(0, open.Length);
            var cell = open[random];
            CreateGO(cell, cells.ToGlobalPosition(cell));
        }
    }

    private int RandomPos()
    {
        var abs = Random.Range(10,15);
        var pos = Random.Range(0, 2) == 0;
        if (pos)
        {
            return abs;
        }
        return -abs;
    }


    private void CreateGO(Vector2Int cell, Vector2 world)
    {
        var sp = Instantiate(solarPanel, world, transform.rotation);
        var tr = Instantiate(tracker, world, transform.rotation);
        tr.transform.SetParent(sp.transform);
        cells.Add(cell, sp);
        solarPanelCount++;
    }

    public void Die()
    {
        solarPanelCount--;
    }
}
