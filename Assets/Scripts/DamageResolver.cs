using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DamageResolver : MonoBehaviour
{
    int damage;
    public Action<GameObject, int> DoDamage;

    [SerializeField]
    string name;

    BattleController battleController;

    void OnEnable()
    {
        battleController = Camera.main.gameObject.GetComponent<BattleController>();
    }

    void OnCollisionStay(Collision col)
    {
        AttackController attackController = col.gameObject.GetComponent<AttackController>();
        if(attackController != null && attackController.isAttacking)
        {
            damage = (int)(Math.Pow(attackController.attackLevel, 2)) + 10;
            DoDamage?.Invoke(gameObject, damage);
            attackController.isAttacking = false;
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "AI" || col.gameObject.tag == "Player")
        {
            return;
        }

        AttackController attackController = col.gameObject.GetComponent<AttackController>();

        if(attackController != null && attackController.isAttacking)
        {
            damage = (int)(Math.Pow(attackController.attackLevel, 2)) + 10;
            battleController.HandleApplyDamage(gameObject, damage);
            attackController.isAttacking = false;
            Destroy(col.gameObject);
        }
    }
}
