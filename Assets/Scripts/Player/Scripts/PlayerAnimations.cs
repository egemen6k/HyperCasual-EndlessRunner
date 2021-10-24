using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    [SerializeField]
    private Animator _anim;
    [SerializeField]
    private CharacterController _cc;
    public ParticleSystem _dirtParticle;
    private IInput _inputPC;
    public bool _isSliding;
    private CharacterMovement _characterMovement;

    private void Start()
    {
        _inputPC = GetComponent<IInput>();
        _anim.SetBool("Run_Anim", true);
        _characterMovement = GetComponent<CharacterMovement>();
    }

    private void Update()
    {
        if (_cc.isGrounded)
        {
            _anim.SetBool("Jump_Anim", false);

            if (!_isSliding)
            {
                _anim.speed = _characterMovement._speed / 10;
            }

            if (!_dirtParticle.isPlaying)
            {
                _dirtParticle.Play();
            }
        }
        else
        {
            StartCoroutine(Jump());
            _dirtParticle.Stop();
        }

        if (_inputPC.GetSlideInput() && !_isSliding && _cc.isGrounded)
        {
            StartCoroutine(Slide());
        }
    }

    IEnumerator Slide()
    {
        _anim.speed = 1f;
        _isSliding = true;
        _dirtParticle.Stop();
        _anim.SetBool("isSliding", true);
        _cc.center = new Vector3(0f, -0.5f, 0f);
        _cc.height = 1f;
        yield return new WaitForSeconds(1f);
        _anim.SetBool("isSliding", false);
        _cc.center = new Vector3(0f, 0f, 0f);
        _cc.height = 2f;
        _isSliding = false;
    }

    IEnumerator Jump()
    {
        _anim.speed = 1f;
        _anim.SetBool("Jump_Anim", true);
        _cc.center = new Vector3(0, 0.8f, 0);
        yield return new WaitForSeconds(.65f);
        _cc.center = new Vector3(0, 0.28f, 0);
    }
}
