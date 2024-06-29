using UnityEngine;
using UnityEngine.SceneManagement;

public class SharpThing : MonoBehaviour
{
    LifeController lifeController;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<CharacterEffects>().StartBlinking();
            if(lifeController == null)
            {
                lifeController = FindObjectOfType<LifeController>();
            }
            lifeController.DecreaseLifes();
        }
    }
}
