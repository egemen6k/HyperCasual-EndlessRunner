using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaneMovement : MonoBehaviour, IMoveHorizontal
{
    [SerializeField]
    private float _LaneSmoothness = 10f;

    public Vector3 GetPosition(int lane, float laneDistance)
    {
        Vector3 targetPosition = transform.up * transform.position.y + transform.forward * transform.position.z;

        if (lane == 2)
        {
            targetPosition += Vector3.right * laneDistance;
        }
        else if (lane == 0)
        {
            targetPosition += Vector3.left * laneDistance;
        }

        Vector3 newPosition = Vector3.Lerp(transform.position, targetPosition, _LaneSmoothness * Time.deltaTime);
        return newPosition;
    }
}
