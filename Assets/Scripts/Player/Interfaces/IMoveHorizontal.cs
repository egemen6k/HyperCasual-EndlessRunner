using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMoveHorizontal
{
    Vector3 GetPosition(int lane, float laneDistance);
}
