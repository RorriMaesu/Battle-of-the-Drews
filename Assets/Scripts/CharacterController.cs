using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CharacterController : MonoBehaviour
{
    [SerializeField]
    protected Animator animator;

    [SerializeField]
    private int speed;

    [SerializeField]
    private int jumpHeight;

    [SerializeField]
    protected Rigidbody rigidbody;

    [SerializeField]
    private AttackController attackController;

    public bool isFacingLeft = true;

    private bool isJumping = false;

    public Action Attack1;
    public Action Attack2;
    public Action Attack3;
    public Action JumpUp;

    private bool isPlayer;

    public bool canIMove = true;

    public virtual void Update()
    {
        isPlayer = gameObject.tag == "Player";
        if(isPlayer && canIMove)
        {
            if(Input.GetKey(KeyCode.LeftArrow))
            {
                MoveLeft();
            }
            else if(Input.GetKey(KeyCode.RightArrow))
            {
                MoveRight();
            }

            if(Input.GetKeyDown(KeyCode.UpArrow))
            {
                Jump();
            }

            if(Input.GetKeyDown(KeyCode.Z))
            {
                AttackWith1();
            }
            else if(Input.GetKeyDown(KeyCode.X))
            {
                AttackWith2();
            }
            else if(Input.GetKeyDown(KeyCode.C))
            {
                AttackWith3();
            }
        }
    }

    void MoveLeft()
    {
        if(!isFacingLeft)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            isFacingLeft = true;
        }

        transform.position += new Vector3(speed * -1 * Time.deltaTime, 0, 0);
    }

    void MoveRight()
    {
        if(isFacingLeft)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
            isFacingLeft = false;
        }

        transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
    }

    public void Jump()
    {
        if(!isJumping)
        {
            isJumping = true;
            JumpUp?.Invoke();
            rigidbody.AddForce(new Vector3(0, jumpHeight, 0), ForceMode.Impulse);
            StartCoroutine(Jumping());
        }
    }

    IEnumerator Jumping()
    {
        yield return new WaitForSeconds(1f);
        isJumping = false;
    }

    public void AttackWith1()
    {
        attackController.isAttacking = true;
        attackController.attackLevel = 1;
        Attack1?.Invoke();
    }

    public void AttackWith2()
    {
        attackController.isAttacking = true;
        attackController.attackLevel = 2;
        Attack2?.Invoke();
    }

    public void AttackWith3()
    {
        attackController.isAttacking = true;
        attackController.attackLevel = 3;
        Attack3?.Invoke();
    }

    public void ResetAfterFrozen(CharacterController playerController, BoxCollider boxCollider, SpriteRenderer renderer, AICharacterController aiController = null)
    {
        StartCoroutine(playerController.ResetCharacter(playerController, boxCollider, renderer, aiController));
    }

    public IEnumerator ResetCharacter(CharacterController playerController, BoxCollider boxCollider, SpriteRenderer renderer, AICharacterController aiController = null)
    {
        yield return new WaitForSeconds(1f);

        if(aiController != null)
        {
            aiController.enabled = true;
        }

        if(playerController != null)
        {
            playerController.canIMove = true;
        }

        if(boxCollider != null)
        {
            boxCollider.enabled = true;
        }

        if(rigidbody != null)
        {
            rigidbody.useGravity = true;
            rigidbody.isKinematic = false;
        }

        if(renderer != null)
        {
            renderer.color = Color.white;
        }
    }
}
