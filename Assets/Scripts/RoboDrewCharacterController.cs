using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoboDrewCharacterController : CharacterController
{
    [SerializeField]
    GameObject bomb;

    [SerializeField]
    GameObject missile;

    [SerializeField]
    GameObject spawnPoint;

    [SerializeField]
    GameObject beam;

    GameObject currentBeam;

    bool canShoot = true;

    void OnEnable()
    {
        gameObject.name = "RoboDrew";
        Attack1 += Bomb;
        Attack2 += Rocket;
        Attack3 += ChargeShot;
        JumpUp += Jump;
    }

    void OnDisable()
    {
        Attack1 -= Bomb;
        Attack2 -= Rocket;
        Attack3 -= ChargeShot;
        JumpUp -= Jump;
    }

    void Bomb()
    {
        animator.Play("RoboDrew_Bomb");
        rigidbody.AddForce(new Vector3(0, 6, 0), ForceMode.Impulse);
        Instantiate(bomb, this.transform.position, Quaternion.Euler(0, 0, 0));
    }

    void Rocket()
    {
        if(canShoot)
        {
            animator.Play("RoboDrew_Rocket");
            if(isFacingLeft)
            {
                GameObject shot = Instantiate(missile, spawnPoint.transform.position, Quaternion.Euler(0, 0, 0));
                ProjectileController projectileController = shot.GetComponent<ProjectileController>();
                if(projectileController != null)
                {
                    projectileController.left = true;
                }
            }
            else
            {
                GameObject shot = Instantiate(missile, spawnPoint.transform.position, Quaternion.Euler(0, 0, -180));
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

    void ChargeShot()
    {
        animator.Play("RoboDrew_ChargeBeam");
    }

    public override void Update()
    {
        if(Input.GetKeyDown(KeyCode.C))
        {
            currentBeam = Instantiate(beam, spawnPoint.transform.position, Quaternion.Euler(0, 0, 0));
        }
        else if(Input.GetKey(KeyCode.C))
        {
            if(currentBeam != null)
            {
                currentBeam.transform.localScale += new Vector3(0.01f, 0.01f, 0.01f);
            }
        }
        else if(Input.GetKeyUp(KeyCode.C))
        {
            LaunchBeam();
        }

        if(currentBeam != null)
        {
            if(currentBeam.transform.localScale.x > 1f)
            {
                LaunchBeam();
            }
        }
        base.Update();
    }

    void LaunchBeam()
    {
        if(currentBeam != null)
        {
            ProjectileController projectileController = currentBeam.GetComponent<ProjectileController>();
            currentBeam = null;
            if(projectileController != null)
            {
                projectileController.enabled = true;
                if(isFacingLeft)
                {
                    projectileController.left = true;
                }
                else
                {
                    projectileController.left = false;
                }
            }
        }
    }

    void Jump()
    {
        animator.Play("RoboDrew_Jump");
    }
}
