using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AndreaCharacterController : CharacterController
{
    [SerializeField]
    GameObject arrow;

    [SerializeField]
    GameObject bomb;

    bool canShoot = true;

    void OnEnable()
    {
        gameObject.name = "Andrea";
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
        animator.Play("Andrea_SwordStrike");
    }

    void ShootArrow()
    {
        if (canShoot)
        {
            animator.Play("Andrea_ShootArrow");

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
            animator.Play("Andrea_BombToss");
            StartCoroutine(BombTossDelay());
        }
    }

    void Jump()
    {
        animator.Play("Andrea_Jump");
    }
}
