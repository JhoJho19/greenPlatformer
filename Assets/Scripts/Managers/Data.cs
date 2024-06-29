using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Data : MonoBehaviour
{
    private static int Crystals;

    public static int GetCrystals()
    { return Crystals; }

    public static void SetCrystals(int increament)
    { Crystals += increament; }
}
