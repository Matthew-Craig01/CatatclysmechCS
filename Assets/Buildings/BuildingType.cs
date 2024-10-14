// BuildingType.cs
using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public class BuildingType
{
    public string buildingName;
    public GameObject prefab;
    public Sprite icon;
    public Sprite placementIndicator;
    public int cost;
    public string description; 
    public int powerCost;

    [Header("Powers")]
    public List<Power> powers;
}
