using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BathroomsignDrewCharacterController : CharacterController
{
    [SerializeField]
    GameObject potty;

    bool canShoot = true;

    void OnEnable()
    {
        gameObject.name = "BathroomsignDrew";

        Attack1 += Punch;
        Attack2 += Kick;
        Attack3 += ThrowPotty;
        JumpUp += Jump;
    }

    void OnDisable()
    {
        Attack1 -= Punch;
        Attack2 -= Kick;
        Attack3 -= ThrowPotty;
        JumpUp -= Jump;
    }

    void Punch()
    {
        animator.Play("BathroomsignDrew_Punch");
    }

    void Kick()
    {
        animator.Play("BathroomsignDrew_Kick");
    }

    void ThrowPotty()
    {
        animator.Play("BathroomsignDrew_ThrowPotty");

        if (canShoot)
        {
            if (isFacingLeft)
            {
                GameObject shot = Instantiate(potty, gameObject.transform.position, Quaternion.Euler(0, 0, 0));
                ProjectileController shotController = shot.GetComponent<ProjectileController>();
                if (shotController != null)
                {
                    shotController.left = true;
                }
            }
            else
            {
                GameObject shot = Instantiate(potty, gameObject.transform.position, Quaternion.Euler(0, 0, 0));
                ProjectileController shotController = shot.GetComponent<ProjectileController>();
                if (shotController != null)
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
        animator.Play("BathroomsignDrew_Jump");
    }
}
