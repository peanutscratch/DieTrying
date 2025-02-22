using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening; //DOTween Library

public class BodyExplosion : MonoBehaviour
{
    //attach particle system for explosion
    public ParticleSystem ps;
    public Animator animator;
    public string animState;
    public int animID;
    public float delayTimer = 1.0f;



    public void Explode()
    {
        ps.Play();
        animator.Play(animState,animID);

    }

    public void KillObject()
    {
        Destroy(gameObject, delayTimer);
    }
}
