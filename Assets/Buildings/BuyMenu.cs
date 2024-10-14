using System;
using UnityEngine;
using UnityEngine.UI;

public class BuyMenu : MonoBehaviour
{
    public GameObject buyMenuPanel;
    public Transform contentPanel;
    public GameObject buyMenuItemPrefab;
    public Button closeButton;

    private BuildingPlacementManager placementManager;
    private Action onCloseCallback;

    public GameObject alexisPrefab;

    void Start()
    {
        placementManager = GameObject.FindWithTag("BPM").GetComponent<BuildingPlacementManager>();
        Hide();

        if (closeButton != null)
        {
            closeButton.onClick.AddListener(CloseMenu);
        }
    }

    public void Show(Action onClose)
    {
        onCloseCallback = onClose;
        buyMenuPanel.SetActive(true);
        PopulateBuyMenu();
    }

    public void Hide()
    {
        buyMenuPanel.SetActive(false);
    }

    private void CloseMenu()
    {
        Hide();
        onCloseCallback?.Invoke();
    }

    private void PopulateBuyMenu()
    {
        foreach (Transform child in contentPanel)
        {
            Destroy(child.gameObject);
        }

        for (int i = 0; i < placementManager.buildingTypes.Count; i++)
        {
            BuildingType building = placementManager.buildingTypes[i];

            GameObject item = Instantiate(buyMenuItemPrefab, contentPanel);
            BuyMenuItem menuItem = item.GetComponent<BuyMenuItem>();
            if (menuItem != null)
            {
                menuItem.Setup(building, i);
            }
        }
    }
}
