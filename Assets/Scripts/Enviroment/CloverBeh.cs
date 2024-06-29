using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloverBeh : MonoBehaviour
{
    [SerializeField] Animator animator;
    Clovers clovers;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            StartCoroutine(AnimationAndDestroy());
            if (clovers == null)
            {
                clovers = FindObjectOfType<Clovers>();
            }
            clovers.CloverIncrease();
        }
    }

    IEnumerator AnimationAndDestroy()
    {
        animator.SetTrigger("Destroy");
        yield return new WaitForSeconds(.25f);
        Destroy(gameObject);
    }
}
