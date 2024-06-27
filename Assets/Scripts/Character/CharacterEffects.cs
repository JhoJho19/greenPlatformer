using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterEffects : MonoBehaviour
{
    [SerializeField] SpriteRenderer spriteRenderer;
    public float blinkdelay = 0.25f;

    public void StartBlinking()
    {
        StartCoroutine(Blink());
    }

    private IEnumerator Blink()
    {
        if (spriteRenderer != null)
        {
            for (int i = 0; i < 3; i++)
            {
                spriteRenderer.enabled = false;
                yield return new WaitForSeconds(blinkdelay);
                spriteRenderer.enabled = true;
                yield return new WaitForSeconds(blinkdelay);
            }
        }
    }
}
