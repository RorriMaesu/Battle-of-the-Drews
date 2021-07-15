using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PandrewCharacterController : CharacterController
{
    void OnEnable()
    {
        gameObject.name = "Pandrew";
        Attack1 += IronTail;
        Attack2 += Headbutt;
        Attack3 += Zap;
        JumpUp += Jump;
    }

    void OnDisable()
    {
        Attack1 -= IronTail;
        Attack2 -= Headbutt;
        Attack3 -= Zap;
        JumpUp -= Jump;
    }

    void IronTail()
    {
        animator.Play("Pandrew_IronTail");
    }

    void Headbutt()
    {
        animator.Play("Pandrew_Headbutt");
    }

    void Zap()
    {
        animator.Play("Pandrew_Zap");
    }

    void Jump()
    {
        animator.Play("Pandrew_Jump");
    }
}
