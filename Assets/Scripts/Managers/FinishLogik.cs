using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLogics : MonoBehaviour
{
    [SerializeField] ParticleSystem _particleSystem;
    [SerializeField] GameObject wheel;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<PlayerController>().enabled = false;
            _particleSystem.Play();
            Invoke("ShowWheel", 0.5f);
        }
    }

    void ShowWheel() 
    { 
        wheel.gameObject.SetActive(true);
    }
}
