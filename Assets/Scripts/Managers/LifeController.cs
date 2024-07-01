using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LifeController : MonoBehaviour
{
    [SerializeField] Image[] lifes;
    Color newColor = new Color(0f, 0f, 0f, 0.1f);

    public void DecreaseLifes()
    {
        if (Data.GetEnergy() > 0)
        {
            Data.SetEnergy(-1);

            for (int i = 4; i >= Data.GetEnergy(); i--)
            {
                if (i < lifes.Length)
                {
                    lifes[i].color = newColor;
                }
            }

            if (Data.GetEnergy() == 0)
            {
                FindObjectOfType<GameOverScreen>().ShowGameOverScreen();
                if (Data.GetEnergy() > 0)
                {
                    Scene currentScene = SceneManager.GetActiveScene();
                    SceneManager.LoadScene(currentScene.name);
                }
                else 
                {
                    GameObject.Find("ImageGameOver").SetActive(true);
                }
            }
        }
    }
}
