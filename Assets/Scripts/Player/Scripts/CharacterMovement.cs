using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float _speed = 8f;
    private float _maxSpeed = 25f;
    private Vector3 _velocity;
    private CharacterController _cc;
    private IInput InputCalculation;
    [SerializeField]
    private int _lane = 1;
    [SerializeField]
    private float _laneDistance = 3.5f;
    [SerializeField]
    private float _LaneSmoothness = 10f;

    void Start()
    {
        _cc = GetComponent<CharacterController>();
        InputCalculation = GetComponent<IInput>();
        _speed = GameManager.Instance.speedStatic;
    }

    void Update()
    {
        //Horizontal Movement
        _lane = InputCalculation.GetHorizontalInput(_lane);
        transform.position = GetPosition(_lane, _laneDistance);
        _cc.center = _cc.center;

        //Forward Movement
        _velocity = Vector3.forward * _speed;
        _velocity = InputCalculation.GetJumpInput(_velocity);
        _cc.Move(_velocity * Time.deltaTime);


        if (_speed < _maxSpeed)
        {
            _speed += 0.1f * Time.deltaTime;
        }
    }  
        
    
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
