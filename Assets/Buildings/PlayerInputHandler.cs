using UnityEngine;

public class PlayerInputHandler : MonoBehaviour
{
    private BuildingPlacementManager bpm;
    void Start()
    {
        bpm = GameObject.FindWithTag("BPM").GetComponent<BuildingPlacementManager>();
    }
    void Update()
    {
        HandleNumberKeyInput();
    }

    private void HandleNumberKeyInput()
    {
        for (int i = 0; i < 3; i++)
        {
            KeyCode key = KeyCode.Alpha1 + i;

            if (Input.GetKeyDown(key))
            {
                int buildingIndex = i;

                bpm.SelectBuilding(buildingIndex);
                bpm.EnterPlacementMode();
            }
        }
    }
}
