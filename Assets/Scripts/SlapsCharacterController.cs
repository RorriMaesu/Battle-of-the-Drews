using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlapsCharacterController : CharacterController
{

    void OnEnable()
    {
        gameObject.name = "Slaps";
        Attack1 += Slap;
        Attack2 += Explode;
        Attack3 += Magic;
        JumpUp += Jump;
    }

    void OnDisable()
    {
        Attack1 -= Slap;
        Attack2 -= Explode;
        Attack3 -= Magic;
        JumpUp -= Jump;
    }

    void Slap()
    {
        animator.Play("Slaps_Slap"); 
    }

    void Magic()
    {
        animator.Play("Slaps_Magic");
    }

    void Explode()
    {
        animator.Play("Slaps_Explode");
    }

      
    void Jump()
    {
        animator.Play("Slaps_Jump");
    }
}
