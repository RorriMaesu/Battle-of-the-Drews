using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoodleDrewCharacterController : CharacterController
{
    [SerializeField]
    GameObject arrow;

    [SerializeField]
    GameObject bomb;

    bool canShoot = true;

    void OnEnable()
    {
        gameObject.name = "DoodleDrew";
        Attack1 += SwordStrike;
        Attack2 += ShootArrow;
        Attack3 += ThrowBomb;
        JumpUp += Jump;
    }

    void OnDisable()
    {
        Attack1 -= SwordStrike;
        Attack2 -= ShootArrow;
        Attack3 -= ThrowBomb;
        JumpUp -= Jump;
    }

    void SwordStrike()
    {
        animator.Play("DoodleDrew_SwordStrike");
    }

    void ShootArrow()
    {
        if (canShoot)
        {
            animator.Play("DoodleDrew_ShootArrow");

            if (isFacingLeft)
            {
                GameObject shot = Instantiate(arrow, gameObject.transform.position, Quaternion.Euler(0, 0, 90));
                ProjectileController shotController = shot.GetComponent<ProjectileController>();
                if (shotController != null)
                {
                    shotController.left = true;
                }
            }
            else
            {
                GameObject shot = Instantiate(arrow, gameObject.transform.position, Quaternion.Euler(0, 0, -90));
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

    IEnumerator BombTossDelay()
    {
        yield return new WaitForSeconds(0.5f);

        if (isFacingLeft)
        {
            GameObject shot = Instantiate(bomb, gameObject.transform.position, Quaternion.Euler(0, 0, 90));
            ProjectileController shotController = shot.GetComponent<ProjectileController>();
            if (shotController != null)
            {
                shotController.left = true;
            }
        }
        else
        {
            GameObject shot = Instantiate(bomb, gameObject.transform.position, Quaternion.Euler(0, 0, -90));
            ProjectileController shotController = shot.GetComponent<ProjectileController>();
            if (shotController != null)
            {
                shotController.left = false;
            }
        }
        StartCoroutine(Cooldown());
    }

    void ThrowBomb()
    {
        if (canShoot)
        {
            animator.Play("DoodleDrew_BombToss");
            StartCoroutine(BombTossDelay());
        }
    }

    void Jump()
    {
        animator.Play("DoodleDrew_Jump");
    }
}
