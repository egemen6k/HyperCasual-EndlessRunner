using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionBehav : MonoBehaviour
{
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.CompareTag("Obstacle"))
        {
            Time.timeScale = 0f;
            GameObject.Find("Canvas").GetComponent<UIManager>().collisionBehav();
        }
    }
}
