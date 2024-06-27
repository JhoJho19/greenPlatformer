using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDestroyer : MonoBehaviour
{
    [SerializeField] GameObject gameObjectThis;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            StartCoroutine(AnimationAndDestroy());
        }
    }

    IEnumerator AnimationAndDestroy()
    {
        //animator.SetTrigger("Destroy");
        yield return new WaitForSeconds(.1f);
        Destroy(gameObjectThis);
    }
}