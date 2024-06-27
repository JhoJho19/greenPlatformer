using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonFly : MonoBehaviour
{
    [SerializeField] private float speed = 2f;

    void FixedUpdate()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("EnemyDestroyer"))
        {
            Destroy(gameObject);
        }
    }
}
