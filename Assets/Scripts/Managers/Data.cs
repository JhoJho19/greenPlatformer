using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Data : MonoBehaviour
{
    private static int Crystals;
    private static int Energy = 5;

    public static int GetCrystals()
    { return Crystals; }

    public static void SetCrystals(int increament)
    { Crystals += increament; }

    public static int GetEnergy()
    { return Energy; }

    public static void SetEnergy(int increament)
    { 
        Energy += increament; 
        if (Energy < 0)
        { Energy = 0; }
    }

    public static void Save()
    {
        ;
    }
}
