using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    [SerializeField]
    private Animator _anim;
    [SerializeField]
    private CharacterController _cc;

    private void Awake()
    {
        _anim.SetBool("Run_Anim", true);
    }

    private void Update()
    {
        if (_cc.isGrounded)
        {
            _anim.SetBool("Jump_Anim", false);
        }
        else
        {
            _anim.SetBool("Jump_Anim", true);
        }
    }
}
