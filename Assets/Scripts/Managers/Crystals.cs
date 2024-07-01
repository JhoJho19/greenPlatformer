using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Crystals : MonoBehaviour
{
    public int crystals { get; private set; }
    [SerializeField] TextMeshProUGUI textCrystals;

    void Start()
    {
        crystals = Data.GetCrystals();
        textCrystals.text = crystals.ToString();
    }

    public void CrystalsIncrease()
    {
        crystals++;
        textCrystals.text = crystals.ToString();
    }
}
