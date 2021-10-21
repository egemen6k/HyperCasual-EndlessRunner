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

    private bool _isSliding = false;

    public Animator _anim;

    private void Start()
    {

    }

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

    private void Update()
    {
        GetSlideInput();
    }
    public void GetSlideInput()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow) && !_isSliding)
        {
            StartCoroutine(Slide());
        }
    }

    IEnumerator Slide()
    {
        _isSliding = true;
        _anim.SetBool("isSliding", true);
        _cc.center = new Vector3(0f, -0.5f, 0f);
        _cc.height = 1f;
        yield return new WaitForSeconds(1f);
        _anim.SetBool("isSliding", false);
        _cc.center = new Vector3(0f, 0f, 0f);
        _cc.height = 2f;
        _isSliding = false;
    }
}
