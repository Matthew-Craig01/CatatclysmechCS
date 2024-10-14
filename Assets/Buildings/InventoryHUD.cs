// InventoryHUD.cs
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using TMPro;

public class InventoryHUD : MonoBehaviour
{
    public TextMeshProUGUI cannonText;
    public TextMeshProUGUI catapultText;
    public TextMeshProUGUI wallText;
    public Button cannonButton;
    public Button catapultButton;
    public Button wallButton;
    public Image cannonImage;
    public Image catapultImage;
    public Image wallImage;
    public Color dimmed;
    public BuildingPlacementManager bpm;

    private Dictionary<int, int> inventory;

    void Start()
    {
        cannonButton.onClick.AddListener(() => {
            bpm.SelectBuilding(0);
            bpm.EnterPlacementMode();
        });
        catapultButton.onClick.AddListener(() => {
            bpm.SelectBuilding(1);
            bpm.EnterPlacementMode();
        });
        wallButton.onClick.AddListener(() => {
            bpm.SelectBuilding(2);
            bpm.EnterPlacementMode();
        });
    }

    public void UpdateInventory(Dictionary<int, int> inventory)
    {
        this.inventory = inventory;
        cannonText.text = "" + inventory[0];
        catapultText.text = "" + inventory[1];
        wallText.text = "" + inventory[2];
        SetDimmed();
    }

    public void SetDimmed()
    {
        if (inventory[0] == 0)
        {
            Debug.Log("Dimming Cannon");
            cannonImage.color = dimmed;
        }
        else
        {
            cannonImage.color = Color.white;
        }
        if (inventory[1] == 0)
        {
            catapultImage.color = dimmed;
        }
        else
        {
            catapultImage.color = Color.white;
        }
        if (inventory[2] == 0)
        {
            wallImage.color = dimmed;
        }
        else
        {
            wallImage.color = Color.white;
        }

    }

    public void HighlightBuilding(int index)
    {
        ClearHighlight();
        if (index == 0)
        {
            cannonImage.color = Color.yellow;
        }
        if (index == 1)
        {
            catapultImage.color = Color.yellow;
        }
        if (index == 2)
        {
            wallImage.color = Color.yellow;
        }
    }

    public void ClearHighlight()
    {
        cannonImage.color = Color.white;
        catapultImage.color = Color.white;
        wallImage.color = Color.white;
        SetDimmed();
    }
}
