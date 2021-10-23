using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField]
    private float _speed = 8f;
    private Vector3 _velocity;

    private CharacterController _cc;
    private IInput InputCalculation;
    private IMoveHorizontal Horizontal;

    [SerializeField]
    private int _lane = 1;
    [SerializeField]
    private float _laneDistance = 3.5f;

    void Start()
    {
        _cc = GetComponent<CharacterController>();
        if (_cc == null)
        {
            Debug.LogError("Character Controller is null");
        }

        InputCalculation = GetComponent<IInput>();
        if (InputCalculation == null)
        {
            Debug.LogError("Input interface is returning null");
        }

        Horizontal = GetComponent<IMoveHorizontal>();
        if (Horizontal == null)
        {
            Debug.LogError("Horizontal movement is returning null");
        }
    }

    void Update()
    {
        //Horizontal Movement
        _lane = InputCalculation.GetHorizontalInput(_lane);
        transform.position = Horizontal.GetPosition(_lane, _laneDistance);
        _cc.center = _cc.center;

        //Forward Movement
        _velocity = Vector3.forward * _speed;
        _velocity = InputCalculation.GetJumpInput(_velocity);
        _cc.Move(_velocity * Time.deltaTime);

    }
}
