using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaptainAndrewCharacterController : CharacterController
{
    [SerializeField]
    GameObject bullet;

    [SerializeField]
    GameObject spawnBulletPoint;

    bool canShoot = true;

    void OnEnable()
    {
        gameObject.name = "CaptainAndrew";
        Attack1 += Kick;
        Attack2 += Shoot;
        Attack3 += AndrewPunch;
        JumpUp += Jump;
    }

    void OnDisable()
    {
        Attack1 -= Kick;
        Attack2 -= Shoot;
        Attack3 -= AndrewPunch;
        JumpUp -= Jump;
    }

    void Kick()
    {
        animator.Play("CaptainAndrew_Kick");
    }

    void Shoot()
    {
        if (canShoot)
        {
            StopAllCoroutines();

            animator.Play("CaptainAndrew_Shoot");

            if (isFacingLeft)
            {
                GameObject shot = Instantiate(bullet, spawnBulletPoint.transform.position, Quaternion.Euler(0, 0, 90));
                ProjectileController shotController = shot.GetComponent<ProjectileController>();
                if (shotController != null)
                {
                    shotController.left = true;
                }
            }
            else
            {
                GameObject shot = Instantiate(bullet, spawnBulletPoint.transform.position, Quaternion.Euler(0, 0, -90));
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

    void AndrewPunch()
    {
        StopAllCoroutines();
        animator.Play("CaptainAndrew_AndrewPunch");
        StartCoroutine(AndrewPunchTimer());
    }

    IEnumerator AndrewPunchTimer()
    {
        yield return new WaitForSeconds(0.5f);

        if(isFacingLeft)
        {
            rigidbody.AddForce(new Vector3(-7, 0, 0), ForceMode.Impulse);
        }
        else
        {
            rigidbody.AddForce(new Vector3(7, 0, 0), ForceMode.Impulse);
        }
    }

    void Jump()
    {
        animator.Play("CaptainAndrew_Jump");
    }

}
