using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SpawnCharacterController : MonoBehaviour
{
    [SerializeField]
    Transform spawnPoint1;

    [SerializeField]
    Transform spawnPoint2;

    [SerializeField]
    Transform spawnPoint3;

    [SerializeField]
    Transform spawnPoint4;

    [SerializeField]
    GameObject respawnPoint1;

    [SerializeField]
    GameObject respawnPoint2;

    [SerializeField]
    GameObject respawnPoint3;

    [SerializeField]
    GameObject respawnPoint4;

    [SerializeField]
    LivesController livesController;

    [SerializeField]
    BattleController battleController;

    public Action MakeAIJump;

    [SerializeField]
    GameObject oriamObject;

    [SerializeField]
    GameObject andyBearObject;

    [SerializeField]
    GameObject pandrewObject;

    [SerializeField]
    GameObject andyThugObject;

    [SerializeField]
    GameObject andreaObject;

    [SerializeField]
    GameObject andyAndiObject;

    [SerializeField]
    GameObject captainAndrewObject;

    [SerializeField]
    GameObject roboDrewObject;

    [SerializeField]
    GameObject bathroomsignDrewObject;

    [SerializeField]
    GameObject doodleDrewObject;

    [SerializeField]
    GameObject slapsObject;

    [SerializeField]
    GameObject mustacheObject;


    int spawned;

    void Awake()
    {
        SpawnCharacter(GameState.P1_Character, spawnPoint1);
        SpawnCharacter(GameState.P2_Character, spawnPoint2);
        SpawnCharacter(GameState.P3_Character, spawnPoint3);
        SpawnCharacter(GameState.P4_Character, spawnPoint4);
    }

    void OnEnable()
    {
        livesController.RespawnCharacter += HandleRespawnCharacter;
    }

    void OnDisable()
    {
        livesController.RespawnCharacter += HandleRespawnCharacter;
    }

    void RespawnCharacter(GameObject go, GameObject respawnPoint, int damageResetPos, int playerNumber)
    {
        GameObject p = Instantiate(go, respawnPoint.transform.position, Quaternion.Euler(0, 0, 0));
        CharacterController characterController = p.GetComponent<CharacterController>();

        if(characterController != null)
        {
            characterController.enabled = true;
        }

        AICharacterController aiCharacterController = p.GetComponent<AICharacterController>();

        if(playerNumber == 1)
        {
            p.tag = "Player";

            if(aiCharacterController != null)
            {
                Destroy(aiCharacterController);
            }
        }
        else
        {
            p.tag = "AI";
            aiCharacterController.enabled = true;
        }

        Animator animator = p.GetComponent<Animator>();
        animator.enabled = true;

        p.transform.position = new Vector3(transform.position.x, transform.position.y, -1);
        battleController.ResetDamageAtPosition(damageResetPos);
        DamageResolver dmgResolver = p.GetComponent<DamageResolver>();
        if(dmgResolver != null)
        {
            dmgResolver.DoDamage += battleController.HandleApplyDamage;
        }
    }

    void HandleRespawnCharacter(GameObject go)
    {
        if(GameState.P1_Character.ToString() == go.name)
        {
            RespawnCharacter(go, respawnPoint1, 0, 1);
        }
        else if(GameState.P2_Character.ToString() == go.name)
        {
            RespawnCharacter(go, respawnPoint2, 1, 2);
        }
        else if(GameState.P3_Character.ToString() == go.name)
        {
            RespawnCharacter(go, respawnPoint3, 2, 3);
        }
        else if(GameState.P4_Character.ToString() == go.name)
        {
            RespawnCharacter(go, respawnPoint4, 3, 4);
        }
    }

    void SpawnCharacter(GameState.Character character, Transform spawnPoint)
    {
        if(character == GameState.Character.AndyBear)
        {
            Instantiate(andyBearObject, spawnPoint.position, Quaternion.Euler(0, 0, 0));
        }
        else if (character == GameState.Character.Oriam)
        {
            Instantiate(oriamObject, spawnPoint.position, Quaternion.Euler(0, 0, 0));
        }
        else if (character == GameState.Character.Andrea)
        {
            Instantiate(andreaObject, spawnPoint.position, Quaternion.Euler(0, 0, 0));
        }
        else if (character == GameState.Character.Pandrew)
        {
            Instantiate(pandrewObject, spawnPoint.position, Quaternion.Euler(0, 0, 0));
        }
        else if (character == GameState.Character.RoboDrew)
        {
            Instantiate(roboDrewObject, spawnPoint.position, Quaternion.Euler(0, 0, 0));
        }
        else if (character == GameState.Character.AndyAndi)
        {
            Instantiate(andyAndiObject, spawnPoint.position, Quaternion.Euler(0, 0, 0));
        }
        else if (character == GameState.Character.AndyThug)
        {
            Instantiate(andyThugObject, spawnPoint.position, Quaternion.Euler(0, 0, 0));
        }
        else if (character == GameState.Character.CaptainAndrew)
        {
            Instantiate(captainAndrewObject, spawnPoint.position, Quaternion.Euler(0, 0, 0));
        }
        else if (character == GameState.Character.BathroomsignDrew)
        {
            Instantiate(bathroomsignDrewObject, spawnPoint.position, Quaternion.Euler(0, 0, 0));
        }
        else if (character == GameState.Character.Slaps)
        {
            Instantiate(slapsObject, spawnPoint.position, Quaternion.Euler(0, 0, 0));
        }
        else if (character == GameState.Character.DoodleDrew)
        {
            Instantiate(doodleDrewObject, spawnPoint.position, Quaternion.Euler(0, 0, 0));
        }
        else if (character == GameState.Character.Mustache)
        {
            Instantiate(mustacheObject, spawnPoint.position, Quaternion.Euler(0, 0, 0));
        }
        spawned++;

        if(spawned == 4)
        {
            GameState.Init();
        }

    }
}
