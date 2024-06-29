using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalBeh : MonoBehaviour
{
    [SerializeField] Animator animator;
    Crystals crystals;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            StartCoroutine(AnimationAndDestroy());
            if(crystals == null) 
            {
                crystals = FindObjectOfType<Crystals>();
            }
            crystals.CrystalsIncrease();
        }
    }

    IEnumerator AnimationAndDestroy() 
    {
        animator.SetTrigger("Destroy");
        yield return new WaitForSeconds(.25f);
        Destroy(gameObject);
    }
}