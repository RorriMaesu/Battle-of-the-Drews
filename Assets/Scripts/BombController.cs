using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombController : MonoBehaviour
{
    [SerializeField]
    Animator animator;

    void Awake()
    {
        StartCoroutine(StartBombTimer());
    }

    IEnumerator StartBombTimer()
    {
        yield return new WaitForSeconds(0.5f);
        Explode();
    }

    void Explode()
    {
        animator.Play("Bomb_Animator");
        StartCoroutine(StartDestroyTimer());
    }

    IEnumerator StartDestroyTimer()
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }
}
