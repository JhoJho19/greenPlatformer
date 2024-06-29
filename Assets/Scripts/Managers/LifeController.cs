using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LifeController : MonoBehaviour
{
    [SerializeField] Image[] lifes;
    Color newColor = new Color(0f, 0f, 0f, 0.1f);
    int lifesCount = 5;

    public void DecreaseLifes()
    {
        if (lifesCount > 0)
        {
            lifesCount--;

            for (int i = 4; i >= lifesCount; i--)
            {
                if (i < lifes.Length)
                {
                    lifes[i].color = newColor;
                }
            }

            if (lifesCount == 0)
            {
                Scene currentScene = SceneManager.GetActiveScene();
                SceneManager.LoadScene(currentScene.name);
            }
        }
    }
}
