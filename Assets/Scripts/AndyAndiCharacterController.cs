using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AndyAndiCharacterController : CharacterController
{
    [SerializeField]
    private Animator andiAnimator;

    [SerializeField]
    private GameObject iceProjectile;

    [SerializeField]
    private Rigidbody andiRigidbody;

    bool canShoot = true;

    void OnEnable()
    {
        gameObject.name = "AndyAndi";
        Attack1 += Smash;
        Attack2 += HitIce;
        Attack3 += FreezeBlast;
        JumpUp += Jump;
    }

    void OnDisable()
    {
        Attack1 -= Smash;
        Attack2 -= HitIce;
        Attack3 -= FreezeBlast;
        JumpUp -= Jump;
    }

    void Jump()
    {
        animator.Play("Andy_Jump");
        if(andiAnimator != null)
        {
            StartCoroutine(Andi_Jump());
        }
    }

    IEnumerator Andi_Jump()
    {
        yield return new WaitForSeconds(0.1f);

        if(andiAnimator != null)
        {
            andiAnimator.Play("Andi_Jump");
        }

        if(andiRigidbody != null)
        {
            andiRigidbody.AddForce(new Vector3(0, 5, 0), ForceMode.Impulse);
        }
    }

    void FreezeBlast()
    {
        animator.Play("Andy_FreezeBlast");

        if(andiAnimator != null)
        {
            StartCoroutine(Andi_Freeze());
        }
    }

    IEnumerator Andi_Freeze()
    {
        yield return new WaitForSeconds(0.1f);

        if(andiAnimator != null)
        {
            andiAnimator.Play("Andi_Freeze");
        }
    }

    void Smash()
    {
        animator.Play("Andy_Smash");
        if(andiAnimator != null)
        {
            StartCoroutine(Andi_Smash());
        }
    }

    IEnumerator Andi_Smash()
    {
        yield return new WaitForSeconds(0.1f);
        if(andiAnimator != null)
        {
            andiAnimator.Play("Andi_Smash");
        }
    }

    void HitIce()
    {
        if (canShoot)
        {
            animator.Play("Andy_HitIce");

            if (andiAnimator != null)
            {
                StartCoroutine(Andi_HitIce());
            }

            if (isFacingLeft)
            {
                GameObject shot = Instantiate(iceProjectile, gameObject.transform.position, Quaternion.Euler(0, 0, 90));
                ProjectileController projectileController = shot.GetComponent<ProjectileController>();
                if (projectileController != null)
                {
                    projectileController.left = true;
                }
            }
            else
            {
                GameObject shot = Instantiate(iceProjectile, gameObject.transform.position, Quaternion.Euler(0, 0, -90));
                ProjectileController projectileController = shot.GetComponent<ProjectileController>();
                if (projectileController != null)
                {
                    projectileController.left = false;
                }
            }

            StartCoroutine(ShootCooldown());
        }

    }

    IEnumerator ShootCooldown()
    {
        canShoot = false;
        yield return new WaitForSeconds(0.5f);
        canShoot = true;
    }

    IEnumerator Andi_HitIce()
    {
        yield return new WaitForSeconds(0.2f);
        if(andiAnimator != null)
        {
            andiAnimator.Play("Andi_Hit");
        }

        if (isFacingLeft)
        {
            GameObject shot = Instantiate(iceProjectile, gameObject.transform.position, Quaternion.Euler(0, 0, 90));
            ProjectileController projectileController = shot.GetComponent<ProjectileController>();
            if (projectileController != null)
            {
                projectileController.left = true;
            }
        }
        else
        {
            GameObject shot = Instantiate(iceProjectile, gameObject.transform.position, Quaternion.Euler(0, 0, -90));
            ProjectileController projectileController = shot.GetComponent<ProjectileController>();
            if (projectileController != null)
            {
                projectileController.left = false;
            }
        }
    }
}
