using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Utils;

public class Power : MonoBehaviour
{
    // Shop Prices
    // 35 = Catapult = Air and Land + Over Walls
    // 35 = Teleporter
    // 25 = Archer = Air and Land but Weak
    // 25 = Cannon = Land
    // 5 = Wall

    public int power { get; private set; }
    public SolarPanelSpawner spSpawner;
    public int roundBonus = 25;
    public int maxSolarPanelPower = 50;
    public float genRate;
    public TextMeshProUGUI powerText;
    private float lastGen;
    private float roundPower;
    private float maxRoundPower;

    void Start()
    {
        power = 0;
        roundPower = 0;
        RoundEnd(0);
    }

    public void Update()
    {
        if (Time.time - lastGen >= genRate)
        {
            Generate();
            lastGen = Time.time;
            powerText.text = power.ToString();
        }
    }

    public void Generate()
    {
        if (roundPower <= maxRoundPower)
        {
            power += spSpawner.solarPanelCount;
            roundPower += spSpawner.solarPanelCount;
        }
        else
        {
            powerText.color = Color.green;
        }
    }

    public void RoundEnd(int round)
    {
        power += roundBonus;
        maxRoundPower = maxSolarPanelPower * (spSpawner.solarPanelCount + 1);
        roundPower = 0;
        powerText.text = power.ToString();
    }

    public bool Spend(int amount)
    {
        if (power >= amount)
        {
            power -= amount;
            powerText.text = power.ToString();
            return true;
        }
        return false;
    }
}
