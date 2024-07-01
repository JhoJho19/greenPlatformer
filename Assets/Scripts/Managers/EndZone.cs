using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndZone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Data.SetEnergy(-1);
            if(Data.GetEnergy() > 0)
                ReloadCurrentScene();
            else
                FindObjectOfType<GameOverScreen>().ShowGameOverScreen();
        }
    }
    void ReloadCurrentScene()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }
}