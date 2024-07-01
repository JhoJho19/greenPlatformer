using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonSound : MonoBehaviour
{
    [SerializeField] Image image;
    [SerializeField] Sprite spriteOn;
    [SerializeField] Sprite spriteOff;
    public void SoundSwitcher()
    {
        SoundManager.Instance.ToggleSounds();
        if (image.sprite == spriteOn)
        {
            image.sprite = spriteOff;
        }
        else
        {
            image.sprite = spriteOn;
        }
    }

    private void OnEnable()
    {
        if (SoundManager.IsSoundOn)
        {
            image.sprite = spriteOn;
        }
        else
        {
            image.sprite = spriteOff;
        }
    }
}
