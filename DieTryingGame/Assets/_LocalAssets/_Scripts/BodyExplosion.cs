using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening; //DOTween Library

public class BodyExplosion : MonoBehaviour
{
    public Animator animator;
    public string animState;
    public float delayTimer = 1.0f;

    public void Explode()
    {
        animator.Play("Arm");
    }

    public void ExplosionHit()
    {
        //do the hit
    }
}
