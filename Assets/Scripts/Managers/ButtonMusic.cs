using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonMusic : MonoBehaviour
{
    [SerializeField] Image image;
    [SerializeField] Sprite spriteOn;
    [SerializeField] Sprite spriteOff;

    public void MusicSwitcher()
    {
        BackgroundMusic.Instance.ToggleMusic();
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
        if (BackgroundMusic.IsMusicOn) 
        {
            image.sprite = spriteOn;
        }
        else
        {
            image.sprite = spriteOff;
        }
    }
}
