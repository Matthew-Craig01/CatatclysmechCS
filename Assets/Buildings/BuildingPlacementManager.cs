// BuildingPlacementManager.cs
using System;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro; // Needed if you implement UI messages

public class BuildingPlacementManager : MonoBehaviour
{

    public List<BuildingType> buildingTypes;

    [Header("UI References")]
    public BuyMenu buyMenu;
    public InventoryHUD inventoryHUD;

    [Header("Placement Settings")]
    public GameObject placementIndicatorPrefab;
    private GameObject placementIndicatorInstance;
    private SpriteRenderer indicatorSpriteRenderer;

    private bool isPlacing = false;
    private int selectedBuildingIndex = 0;

    private Dictionary<int, int> inventory = new Dictionary<int, int>();

    [Header("Grid Settings")]
    public BuildingCells buildingCells;

    public Vector2 indicatorSize = new Vector2(1f, 1f);

    [Header("Power System")]
    public Power powerSystem;

    void Awake()
    {
        for (int i = 0; i < buildingTypes.Count; i++)
        {
            inventory[i] = 0;
        }
        inventoryHUD.UpdateInventory(inventory);

        if (buildingCells == null)
        {
            buildingCells = FindObjectOfType<BuildingCells>();
        }

        if (powerSystem == null)
        {
            powerSystem = FindObjectOfType<Power>();
        }
    }

    void Start()
    {
        inventoryHUD.UpdateInventory(inventory);
        inventoryHUD.HighlightBuilding(selectedBuildingIndex);
    }

    void Update()
    {
        if (isPlacing)
        {
            HandlePlacement();
        }
    }

    public void BuyBuilding(int buildingIndex)
    {
        if (buildingIndex < 0 || buildingIndex >= buildingTypes.Count)
        {
            return;
        }

        BuildingType building = buildingTypes[buildingIndex];
        int buildingCost = building.cost;

        if (powerSystem == null)
        {
            return;
        }

        bool purchaseSuccessful = powerSystem.Spend(buildingCost);

        if (purchaseSuccessful)
        {
            inventory[buildingIndex] += 1;
            inventoryHUD.UpdateInventory(inventory);
        }
    }

    public void EnterPlacementMode()
    {
        if (!isPlacing)
        {
            isPlacing = true;

            if (placementIndicatorInstance == null)
            {
                placementIndicatorInstance = Instantiate(placementIndicatorPrefab);
                indicatorSpriteRenderer = placementIndicatorInstance.GetComponent<SpriteRenderer>();
            }

            UpdatePlacementIndicator();

            inventoryHUD.HighlightBuilding(selectedBuildingIndex);
        }
        else
        {
            UpdatePlacementIndicator();
        }
    }

    public void ExitPlacementMode()
    {
        isPlacing = false;
        if (placementIndicatorInstance != null)
        {
            Destroy(placementIndicatorInstance);
            placementIndicatorInstance = null;
        }

        inventoryHUD.ClearHighlight();
    }

    private void HandlePlacement()
    {
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPos.z = 0f;

        Vector2Int snappedCell = buildingCells.FromGlobalPosition(mouseWorldPos);
        Vector2 snappedPosition = buildingCells.ToGlobalPosition(snappedCell);

        if (placementIndicatorInstance != null)
        {
            placementIndicatorInstance.transform.position = snappedPosition;
        }

        bool hasInventory = inventory[selectedBuildingIndex] > 0;

        bool isValid = buildingCells.IsValid(snappedCell) && hasInventory;

        if (isValid)
        {
            indicatorSpriteRenderer.color = Color.green;
        }
        else
        {
            if (!buildingCells.IsValid(snappedCell))
                indicatorSpriteRenderer.color = Color.red;
            else
                indicatorSpriteRenderer.color = Color.gray;
        }

        if (Input.GetMouseButtonDown(0) && isValid)
        {
            PlaceBuilding(snappedPosition, snappedCell);
        }

        if (Input.GetMouseButtonDown(1))
        {
            ExitPlacementMode();
        }

        if (Input.mouseScrollDelta.y != 0)
        {
            CycleBuilding((int)Mathf.Sign(Input.mouseScrollDelta.y));
        }

        for (int i = 0; i < buildingTypes.Count; i++)
        {
            if (Input.GetKeyDown((i + 1).ToString()))
            {
                SelectBuilding(i);
            }
        }
    }

    private void PlaceBuilding(Vector3 position, Vector2Int cell)
    {
        BuildingType building = buildingTypes[selectedBuildingIndex];

        if (inventory[selectedBuildingIndex] > 0)
        {
            GameObject placedBuilding = Instantiate(building.prefab, position, Quaternion.identity);
            
            inventory[selectedBuildingIndex] -= 1;
            inventoryHUD.UpdateInventory(inventory);

            buildingCells.Add(cell, placedBuilding);
        }
    }

    private bool CheckPlacementValidity(Vector3 position)
    {
        return buildingCells.IsValid(position);
    }

    private void CycleBuilding(int direction)
    {
        int previousIndex = selectedBuildingIndex;
        selectedBuildingIndex += direction;
        if (selectedBuildingIndex >= buildingTypes.Count)
        {
            selectedBuildingIndex = 0;
        }
        if (selectedBuildingIndex < 0)
        {
            selectedBuildingIndex = buildingTypes.Count - 1;
        }

        UpdatePlacementIndicator();

        inventoryHUD.HighlightBuilding(selectedBuildingIndex);
    }

    public void SelectBuilding(int index)
    {
        selectedBuildingIndex = index;
        inventoryHUD.HighlightBuilding(selectedBuildingIndex);
    }

    private void UpdatePlacementIndicator()
    {
        if (placementIndicatorInstance != null)
        {
            SpriteRenderer spriteRenderer = placementIndicatorInstance.GetComponent<SpriteRenderer>();
            if (spriteRenderer != null)
            {
                spriteRenderer.sprite = buildingTypes[selectedBuildingIndex].placementIndicator;

                placementIndicatorInstance.transform.localScale = new Vector3(indicatorSize.x, indicatorSize.y, 1f);

                Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                mouseWorldPos.z = 0f;
                Vector2Int snappedCell = buildingCells.FromGlobalPosition(mouseWorldPos);
                Vector2 snappedPosition = buildingCells.ToGlobalPosition(snappedCell);
                placementIndicatorInstance.transform.position = snappedPosition;
            }
        }
    }

    public void OpenBuyMenu(Action onClosed)
    {
        buyMenu.Show(onClosed);
    }

    public void CloseBuyMenu()
    {
        buyMenu.Hide();
    }

    public int GetSelectedBuildingIndex()
    {
        return selectedBuildingIndex;
    }

    public bool IsPlacing()
    {
        return isPlacing;
    }

}
