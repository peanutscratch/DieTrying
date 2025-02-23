using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening; //DOTween Library

public class BodyExplosion : MonoBehaviour
{
    public Animator animator;
    public AudioSource ArmSound;
    public AudioSource ExplodeSound;

    public Collider2D explosionCircle;

    public void Start()
    {
        explosionCircle.enabled = false;
    }

    public void Explode()
    {
        animator.Play("Arm");
    }

    public void ExplosionHit()
    {
        //do the hit
    }

    private void Update()
    {
        if (!gameObject.activeSelf)
            gameObject.SetActive(true);
    }
}
