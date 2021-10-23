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
    private InputPC _inputPC;

    private void Awake()
    {
        _anim.SetBool("Run_Anim", true);
    }

    private void Start()
    {
        _inputPC = GetComponent<InputPC>();
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
            if (_inputPC._isSliding)
            {
                StartCoroutine(Slide());
            }
        }
        else
        {
            _anim.SetBool("Jump_Anim", true);
            _dirtParticle.Stop();
        }
    }

    IEnumerator Slide()
    {
        _dirtParticle.Stop();
        _anim.SetBool("isSliding", true);
        _cc.center = new Vector3(0f, -0.5f, 0f);
        _cc.height = 1f;
        yield return new WaitForSeconds(1f);
        _inputPC._isSliding = false;
        _anim.SetBool("isSliding", false);
        _cc.center = new Vector3(0f, 0f, 0f);
        _cc.height = 2f;
    }
}
