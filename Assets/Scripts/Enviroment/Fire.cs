using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    private Coroutine blinkingCoroutine;
    LifeController lifeController;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (blinkingCoroutine == null)
            {
                blinkingCoroutine = StartCoroutine(BlinkingCoroutine(collision.GetComponent<CharacterEffects>()));
                if (lifeController == null)
                {
                    lifeController = FindObjectOfType<LifeController>();
                }
                lifeController.DecreaseLifes();
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            StopCoroutine(blinkingCoroutine);
            if (blinkingCoroutine != null)
            blinkingCoroutine = null;
        }
    }

    private IEnumerator BlinkingCoroutine(CharacterEffects characterEffects)
    {
        while (true)
        {
            characterEffects.StartBlinking();
            yield return new WaitForSeconds(1f);
        }
    }
}
