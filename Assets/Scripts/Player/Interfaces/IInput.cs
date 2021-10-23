using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInput
{
    int GetHorizontalInput(int lane);
    Vector3 GetJumpInput(Vector3 velocity);
    bool GetSlideInput();

}
