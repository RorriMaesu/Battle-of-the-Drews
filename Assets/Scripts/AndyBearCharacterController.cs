using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AndyBearCharacterController : CharacterController
{
    bool isFiring = false;

    void OnEnable()
    {
        gameObject.name = "AndyBear";
        Attack1 += Punch;
        Attack2 += Slash;
        Attack3 += Fire;
        JumpUp += Jump;
    }

    void OnDisable()
    {
        Attack1 -= Punch;
        Attack2 -= Slash;
        Attack3 -= Fire;
        JumpUp -= Jump;
    }

    void Punch()
    {
        animator.Play("AndyBear_Punch");
    }

    void Slash()
    {
        animator.Play("AndyBear_Slash");
    }

    void Fire()
    {
        if(!isFiring)
        {
            isFiring = true;
            animator.Play("AndyBear_Fire");
            StartCoroutine(Firing());
        }
    }

    IEnumerator Firing()
    {
        yield return new WaitForSeconds(1f);
        isFiring = false;
    }

    void Jump()
    {
        animator.Play("AndyBear_Jump");
    }
}
