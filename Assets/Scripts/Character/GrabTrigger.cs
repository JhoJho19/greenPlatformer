using System.Collections;
using UnityEngine;
using System.Threading.Tasks;

public class GrabTrigger : MonoBehaviour
{
    //[SerializeField] private Vector2 finalPosition;
    //[SerializeField] private float movingDuration = 1f;
    //[SerializeField] bool isActiveFromTheLeft = true;
    //PlayerController controller;

    //private void Start()
    //{
    //    controller = FindObjectOfType<PlayerController>();
    //}

    //private void OnTriggerEnter2D(Collider2D other)
    //{
    //        if (other.CompareTag("Player") && isActiveFromTheLeft)
    //        {
    //            if (controller.facingRight)
    //            {
    //                controller.ClimbingAnimation();
    //                StartCoroutine(TeleportPlayerSmoothly(other.transform));
    //            }
    //        }
    //        if (other.CompareTag("Player") && !isActiveFromTheLeft)
    //        {
    //            if (!controller.facingRight)
    //            {
    //                controller.ClimbingAnimation();
    //                StartCoroutine(TeleportPlayerSmoothly(other.transform));
    //            }
    //        }
    //}

    //private IEnumerator TeleportPlayerSmoothly(Transform playerTransform)
    //{
    //    controller.enabled = false;
    //    Vector2 startPosition = playerTransform.position;
    //    Vector2 targetPosition = finalPosition;
    //    float elapsedTime = 0f;

    //    while (elapsedTime < movingDuration)
    //    {
    //        playerTransform.position = Vector2.Lerp(startPosition, targetPosition, elapsedTime / movingDuration);
    //        elapsedTime += Time.deltaTime;
    //        yield return null;
    //    }

    //    playerTransform.position = targetPosition;
    //    controller.enabled = true;
    //}
}
