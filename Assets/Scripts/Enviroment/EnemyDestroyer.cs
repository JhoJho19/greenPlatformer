using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDestroyer : MonoBehaviour
{
    [SerializeField] GameObject gameObjectThis;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            StartCoroutine(AnimationAndDestroy());
        }
    }

    IEnumerator AnimationAndDestroy()
    {
        //animator.SetTrigger("Destroy");
        yield return new WaitForSeconds(.01f);
        Destroy(gameObjectThis);
    }
}