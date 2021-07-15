using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class OutOfBoundsController : MonoBehaviour
{
    public Action<GameState.Character> RemoveLife;
    GameState.Character tempCharacter;

    void OnTriggerEnter(Collider col)
    {
        switch(col.gameObject.name)
        {
            case "AndyBear":
                tempCharacter = GameState.Character.AndyBear;
                break;
            case "Oriam":
                tempCharacter = GameState.Character.Oriam;
                break;
            case "Andrea":
                tempCharacter = GameState.Character.Andrea;
                break;
            case "RoboDrew":
                tempCharacter = GameState.Character.RoboDrew;
                break;
            case "AndyThug":
                tempCharacter = GameState.Character.AndyThug;
                break;
            case "AndyAndi":
                tempCharacter = GameState.Character.AndyAndi;
                break;
            case "Pandrew":
                tempCharacter = GameState.Character.Pandrew;
                break;
            case "CaptainAndrew":
                tempCharacter = GameState.Character.CaptainAndrew;
                break;
            case "BathroomsignDrew":
                tempCharacter = GameState.Character.BathroomsignDrew;
                break;
            case "Mustache":
                tempCharacter = GameState.Character.Mustache;
                break;
            case "Slaps":
                tempCharacter = GameState.Character.Slaps;
                break;
        }

        if(tempCharacter != null)
        {
            RemoveLife?.Invoke(tempCharacter);
        }

        if(col.gameObject != null)
        {
            Destroy(col.gameObject);
        }
    }
}
