using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OriamCharacterController : CharacterController
{
    [SerializeField]
    GameObject beer;

    bool canShoot = true;

    void OnEnable()
    {
        gameObject.name = "Oriam";

        Attack1 += Punch;
        Attack2 += Kick;
        Attack3 += ThrowBeer;
        JumpUp += Jump;
    }

    void OnDisable()
    {
        Attack1 -= Punch;
        Attack2 -= Kick;
        Attack3 -= ThrowBeer;
        JumpUp -= Jump;
    }

    void Punch()
    {
        animator.Play("Oriam_Punch");
    }

    void Kick()
    {
        animator.Play("Oriam_Kick");
    }

    void ThrowBeer()
    {
        animator.Play("Oriam_ThrowBeer");

        if(canShoot)
        {
            if(isFacingLeft)
            {
                GameObject shot = Instantiate(beer, gameObject.transform.position, Quaternion.Euler(0, 0, 0));
                ProjectileController shotController = shot.GetComponent<ProjectileController>();
                if(shotController != null)
                {
                    shotController.left = true;
                }
            }
            else
            {
                GameObject shot = Instantiate(beer, gameObject.transform.position, Quaternion.Euler(0, 0, 0));
                ProjectileController shotController = shot.GetComponent<ProjectileController>();
                if(shotController != null)
                {
                    shotController.left = false;
                }
            }
            StartCoroutine(Cooldown());
        }
    }

    IEnumerator Cooldown()
    {
        canShoot = false;
        yield return new WaitForSeconds(0.5f);
        canShoot = true;
    }

    void Jump()
    {
        animator.Play("Oriam_Jump");
    }
}
