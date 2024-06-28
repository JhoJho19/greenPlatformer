using System.Collections;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float speed = 2f;
    [SerializeField] Collider2D colliderForDestroy;
    public bool movingRight = true;

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        if (movingRight)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        }
    }

    public void Flip()
    {
        movingRight = !movingRight;

        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("EnemyFlipper"))
        {
            Flip();
        }
        if (collision.CompareTag("Player"))
        {
            //colliderForDestroy.enabled = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //colliderForDestroy.enabled = true;
    }
}
