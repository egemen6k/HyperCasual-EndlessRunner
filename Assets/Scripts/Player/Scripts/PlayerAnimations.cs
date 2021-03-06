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

            if (!_dirtParticle.isPlaying)
            {
                _dirtParticle.Play();
            }
            else if (_inputPC.GetSlideInput() && !_isSliding)
            {
                StartCoroutine(Slide());
            }
        }
        else
        {
            _dirtParticle.Stop();
        }

        if (_anim.GetCurrentAnimatorStateInfo(0).IsName("run"))
        {
            _anim.speed = _characterMovement._speed / 10;
        }
        else
        {
            _anim.speed = 1;
        }
    }

    IEnumerator Slide()
    {
        _isSliding = true;
        _dirtParticle.Stop();
        _anim.SetBool("isSliding", true);
        _cc.center = new Vector3(0f, -0.3f, 0f);
        _cc.height = 1f;
        yield return new WaitForSeconds(.5f);
        _anim.SetBool("isSliding", false);
        _cc.center = new Vector3(0f, 0.28f, 0f);
        _cc.height = 2.2f;
        _isSliding = false;
    }

    IEnumerator Jump()
    {
        _anim.SetBool("Jump_Anim", true);
        _cc.center = new Vector3(0, 0.8f, 0);
        yield return new WaitForSeconds(0.65f);
        _cc.center = new Vector3(0, 0.28f, 0);
        _anim.SetBool("Jump_Anim", false);
    }
    public void JumpingAnim()
    {    
        StartCoroutine(Jump());
    }
}
