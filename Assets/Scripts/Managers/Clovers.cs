using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Clovers : MonoBehaviour
{
    [SerializeField] Image clover1;
    [SerializeField] Image clover2;
    [SerializeField] Image clover3;
    int cloverCount;

    public void CloverIncrease()
    {
        cloverCount++;
        if (cloverCount == 1)
        {
            clover1.gameObject.SetActive(true);
        }
        else if (cloverCount == 2) 
        {
            clover1.gameObject.SetActive(true);
            clover2.gameObject.SetActive(true);
        }
        else if (cloverCount == 3)
        {
            clover1.gameObject.SetActive(true);
            clover2.gameObject.SetActive(true);
            clover3.gameObject.SetActive(true);
        }
    }
}
