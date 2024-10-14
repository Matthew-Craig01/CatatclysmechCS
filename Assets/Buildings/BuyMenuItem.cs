using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class BuyMenuItem : MonoBehaviour, IPointerClickHandler
{
    public Image buildingIcon;
    public Text buildingNameText;
    public Text buildingDescriptionText;
    public Text buildingCostText;
    public Button buyButton;

    private BuildingType buildingType;
    private int buildingIndex;

    private BuildingPlacementManager bpm;

    void Start()
    {
        bpm = GameObject.FindWithTag("BPM").GetComponent<BuildingPlacementManager>();
    }

    public void Setup(BuildingType building, int index)
    {
        buildingType = building;
        buildingIndex = index;


        buildingIcon.sprite = building.icon;
        buildingIcon.color = Color.white;

        buildingNameText.text = building.buildingName;
        buildingNameText.color = Color.black;

        buildingDescriptionText.text = building.description;
        buildingDescriptionText.color = Color.black;

        buildingCostText.text = $"Cost: {building.cost}";
        buildingCostText.color = Color.black;

        buyButton.onClick.RemoveAllListeners();
        buyButton.onClick.AddListener(() => BuyBuilding());

        buyButton.interactable = true;

        ColorBlock colors = buyButton.colors;
        colors.normalColor = Color.white;
        colors.highlightedColor = Color.gray;
        colors.pressedColor = Color.grey;
        colors.selectedColor = Color.white;
        colors.disabledColor = new Color(0.5f, 0.5f, 0.5f, 1f);
        buyButton.colors = colors;
    }

    private void BuyBuilding()
    {
        bpm.BuyBuilding(buildingIndex);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            BuyBuilding();
        }
    }
}
