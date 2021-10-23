using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputPC : MonoBehaviour,IInput
{
    [SerializeField]
    private CharacterController _cc;
    [SerializeField]
    private float _jumpForce;
    [SerializeField]
    private float _gravity = 0.15f;
    private float _yVelocity;
    public bool _isSliding = false;

    public int GetHorizontalInput(int lane)
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            lane++;
            if (lane > 2)
            {
                lane = 2;
            }
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            lane--;
            if (lane < 0)
            {
                lane = 0;
            }
        }
        return lane;
    }

    public Vector3 GetJumpInput(Vector3 velocity)
    {
        if (_cc.isGrounded)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                _yVelocity = _jumpForce;
            }
        }
        else
        {
            _yVelocity -= _gravity;
        }
        velocity.y = _yVelocity;
        return velocity;
    }
    public bool GetSlideInput()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
