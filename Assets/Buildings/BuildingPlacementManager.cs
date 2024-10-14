// BuildingPlacementManager.cs
using System;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro; // Needed if you implement UI messages

public class BuildingPlacementManager : MonoBehaviour
{
    public Power powerSystem;

    [Header("Building Types")]
    public List<BuildingType> buildingTypes;

    [Header("UI References")]
    public BuyMenu buyMenu;
    public InventoryHUD inventoryHUD;
    public Text placementMessageText;
    public Text buildingDescriptionDisplay;

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

        buildingDescriptionDisplay.text = buildingTypes[selectedBuildingIndex].description;
        buildingDescriptionDisplay.enabled = true;
        Debug.Log("Displayed initial building description.");
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

        inventory[buildingIndex] += 1;
        inventoryHUD.UpdateInventory(inventory);
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

            if (buildingDescriptionDisplay != null)
            {
                buildingDescriptionDisplay.text = buildingTypes[selectedBuildingIndex].description;
                buildingDescriptionDisplay.enabled = true;
            }
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
            Debug.Log("Destroyed Placement Indicator and exited Placement Mode.");
        }

        inventoryHUD.ClearHighlight();

        if (buildingDescriptionDisplay != null)
        {
            buildingDescriptionDisplay.enabled = false;
            Debug.Log("Hidden building description.");
        }

        Debug.Log("Exited Placement Mode.");
    }

    private void HandlePlacement()
    {
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPos.z = 0f;

        Vector2Int snappedCell = buildingCells.FromGlobalPosition(mouseWorldPos);
        Vector2 snappedPosition = buildingCells.ToGlobalPosition(snappedCell);

        placementIndicatorInstance.transform.position = snappedPosition;

        bool hasInventory = inventory[selectedBuildingIndex] > 0;

        bool isValid = buildingCells.IsValid(snappedCell) && hasInventory;

        if (isValid)
        {
            indicatorSpriteRenderer.color = Color.green;
        }
        else
        {
            if (!buildingCells.IsValid(snappedCell))
            {
                indicatorSpriteRenderer.color = Color.red;
            }
            else
            {
                indicatorSpriteRenderer.color = Color.gray;
            }

        }

        if (Input.GetMouseButtonDown(0) && isValid)
        {
            PlaceBuilding(snappedPosition, snappedCell);
        }

        if (Input.GetMouseButtonDown(1))
        {
            Debug.Log("Right-click detected. Exiting placement mode.");
            ExitPlacementMode();
            ShowPlacementMessage("Exited placement mode.");
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
        else
        {
            ShowPlacementMessage($"No {building.buildingName} left to place!");
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

        if (buildingDescriptionDisplay != null)
        {
            buildingDescriptionDisplay.text = buildingTypes[selectedBuildingIndex].description;
        }

    }

    public void SelectBuilding(int index)
    {
        selectedBuildingIndex = index;
        inventoryHUD.HighlightBuilding(selectedBuildingIndex);
    }

    private void UpdatePlacementIndicator()
    {
        SpriteRenderer spriteRenderer = placementIndicatorInstance.GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = buildingTypes[selectedBuildingIndex].placementIndicator;

        placementIndicatorInstance.transform.localScale = new Vector3(indicatorSize.x, indicatorSize.y, 1f);

        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPos.z = 0f;
        Vector2Int snappedCell = buildingCells.FromGlobalPosition(mouseWorldPos);
        Vector2 snappedPosition = buildingCells.ToGlobalPosition(snappedCell);
        placementIndicatorInstance.transform.position = snappedPosition;
    }

    public void OpenBuyMenu(Action onClosed)
    {
        buyMenu.Show(onClosed);
        Debug.Log("OpenBuyMenu called with callback.");
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

    private void ShowPlacementMessage(string message)
    {
        placementMessageText.text = message;
        placementMessageText.enabled = true;
        CancelInvoke("HidePlacementMessage");
        Invoke("HidePlacementMessage", 2f);
    }

    private void HidePlacementMessage()
    {
        placementMessageText.enabled = false;
    }
}
