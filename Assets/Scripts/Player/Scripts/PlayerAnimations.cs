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

    private void Awake()
    {
        _anim.SetBool("Run_Anim", true);
    }

    private void Start()
    {
        _inputPC = GetComponent<IInput>();
    }

    private void Update()
    {
        if (_cc.isGrounded)
        {
            _anim.SetBool("Jump_Anim", false);
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
        _anim.SetBool("Jump_Anim", true);
        _cc.center = new Vector3(0, 0.8f, 0);
        _cc.height = .1f;
        yield return new WaitForSeconds(.7f);
        _cc.center = new Vector3(0, 0.28f, 0);
        _cc.height = 2f;
    }
}
