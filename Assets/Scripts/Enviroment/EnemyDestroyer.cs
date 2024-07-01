using System.Collections;
using UnityEngine;

public class EnemyDestroyer : MonoBehaviour
{
    [SerializeField] GameObject objectForDestroy;
    [SerializeField] Collider2D colliderOfObjectForDestroy;
    [SerializeField] Collider2D triggerOfObjectForDestroy;
    [SerializeField] Collider2D detectorCollider;
    [SerializeField] bool isFlying;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (!isFlying) 
            {
                detectorCollider.isTrigger = true;
                triggerOfObjectForDestroy.enabled = false;
                colliderOfObjectForDestroy.enabled = false;
            }

            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 16.5f), ForceMode2D.Impulse);
            StartCoroutine(AnimationAndDestroy());
        }
    }

    IEnumerator AnimationAndDestroy()
    {
        if (isFlying) 
        {
            Destroy(objectForDestroy);
        }
        yield return new WaitForSeconds(2f);
        Destroy(objectForDestroy);
    }
}