using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class CharacterAnimator : MonoBehaviour
{
    private Animator _animator;
    private float _dampTime = 0.0f;

    private Renderer [] _meshes;

    void Start()
    {
        _animator = GetComponentInChildren<Animator>();
    }

    public void UpdateAnimator(Vector3 velocity, float angle)
    {
        _animator.SetFloat("Vertical", velocity.z, _dampTime, Time.deltaTime);
        //_animator.SetFloat("Horizontal", velocity.x, _dampTime, Time.deltaTime);
        _animator.SetFloat("Horizontal", angle, _dampTime, Time.deltaTime);
    }
}
