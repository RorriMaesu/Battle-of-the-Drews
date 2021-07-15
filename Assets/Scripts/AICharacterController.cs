using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AICharacterController : MonoBehaviour
{
    [SerializeField]
    CharacterController characterController;

    GameObject player;

    [SerializeField]
    List<GameObject> otherCharacters;

    [SerializeField]
    GameObject target;

    [SerializeField]
    List<GameObject> allCharactersOnBoard;

    SpawnCharacterController spawnCharacterController;
    LivesController livesController;
    GameObject temp;

    void Start()
    {
        otherCharacters = new List<GameObject>();

        if(this.gameObject.tag == "Player")
        {
            this.enabled = false;
        }

        player = GameObject.FindGameObjectWithTag("Player");

        allCharactersOnBoard = new List<GameObject>();

        if(GameState.P1 != null)
        {
            allCharactersOnBoard.Add(GameState.P1);
        }

        if(GameState.P2 != null)
        {
            allCharactersOnBoard.Add(GameState.P2);
        }

        if (GameState.P3 != null)
        {
            allCharactersOnBoard.Add(GameState.P3);
        }

        if (GameState.P4 != null)
        {
            allCharactersOnBoard.Add(GameState.P4);
        }

        foreach(GameObject character in allCharactersOnBoard)
        {
            if(character != gameObject && character != null)
            {
                otherCharacters.Add(character);
            }
        }

        try
        {
            target = otherCharacters[UnityEngine.Random.Range(0, otherCharacters.Count)];
        }
        catch(Exception e) { }

        livesController = Camera.main.gameObject.GetComponent<LivesController>();

        if(livesController != null)
        {
            livesController.RemoveCharacterFromAIList += HandleRemoveCharacterFromList;
        }

        spawnCharacterController = Camera.main.gameObject.GetComponent<SpawnCharacterController>();

        if(spawnCharacterController != null)
        {
            spawnCharacterController.MakeAIJump += HandleJumpOffOfRespawnPlatform;
        }
    }

    void OnDestroy()
    {
        if(livesController != null)
        {
            livesController.RemoveCharacterFromAIList -= HandleRemoveCharacterFromList;
        }

        if(spawnCharacterController != null)
        {
            spawnCharacterController.MakeAIJump -= HandleJumpOffOfRespawnPlatform;
        }
    }

    void Update()
    {
        if(target != null)
        {
            if(target.transform.position.x < gameObject.transform.position.x)
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);
                characterController.isFacingLeft = true;
            }
            else
            {
                transform.rotation = Quaternion.Euler(0, 180, 0);
                characterController.isFacingLeft = false;
            }

            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, 2 * Time.deltaTime);
        }
    }

    void HandleRemoveCharacterFromList(GameObject obj)
    {
        foreach(GameObject go in otherCharacters)
        {
            if(go == obj)
            {
                temp = go;
            }
        }

        otherCharacters.Remove(temp);

        ResetTarget();
    }

    void OnCollisionEnter(Collision collision)
    {
        if(!(gameObject.tag == "Player"))
        {
            int attackNum = UnityEngine.Random.Range(0, 4);

            if(attackNum == 0)
            {
                characterController.AttackWith1();
            }
            else if(attackNum == 1)
            {
                characterController.AttackWith2();
            }
            else if(attackNum == 2)
            {
                characterController.AttackWith3();
            }
            else if(attackNum == 3)
            {
                characterController.Jump();
            }
        }
    }

    void OnCollisionExit(Collision col)
    {
        if(gameObject.tag == "Player")
        {
            return;
        }

        ResetTarget();
    }

    void ResetTarget()
    {
        allCharactersOnBoard = new List<GameObject>();
        otherCharacters = new List<GameObject>();
        
        if(GameState.P1 != null)
        {
            allCharactersOnBoard.Add(GameState.P1);
        }

        if(GameState.P2 != null)
        {
            allCharactersOnBoard.Add(GameState.P2);
        }

        if (GameState.P3 != null)
        {
            allCharactersOnBoard.Add(GameState.P3);
        }

        if (GameState.P4 != null)
        {
            allCharactersOnBoard.Add(GameState.P4);
        }

        foreach(GameObject character in allCharactersOnBoard)
        {
            if(character != gameObject && character != null)
            {
                otherCharacters.Add(character);
            }
        }

        if(otherCharacters.Count == 0)
        {
            return;
        }

        target = otherCharacters[UnityEngine.Random.Range(0, otherCharacters.Count)];
    }

    void HandleJumpOffOfRespawnPlatform()
    {
        characterController.Jump();
        gameObject.transform.parent = null;
    }
}
