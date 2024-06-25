using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InclusionOfAnObject : MonoBehaviour
{
    [SerializeField] GameObject gameObjectForOn;
    [SerializeField] string tagofCollisionObj; 

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(tagofCollisionObj))
        {
            gameObjectForOn.SetActive(true);
        }
    }
}
