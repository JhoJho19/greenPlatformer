using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnergyCounterOutput : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI energyCount;

    private void Start()
    {
        RefreshEnergyCounter();
    }

    public void RefreshEnergyCounter()
    {
        energyCount.text = $"{Data.GetEnergy()}/5";
    }
}
