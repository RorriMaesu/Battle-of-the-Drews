using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class LivesController : MonoBehaviour
{
    int p1Lives;
    int p2Lives;
    int p3Lives;
    int p4Lives;

    [SerializeField]
    List<GameObject> p1LivesList;

    [SerializeField]
    List<GameObject> p2LivesList;

    [SerializeField]
    List<GameObject> p3LivesList;

    [SerializeField]
    List<GameObject> p4LivesList;

    [SerializeField]
    Sprite oriam;

    [SerializeField]
    Sprite andyBear;

    [SerializeField]
    Sprite pandrew;

    [SerializeField]
    Sprite andyThug;

    [SerializeField]
    Sprite andrea;

    [SerializeField]
    Sprite andyAndi;

    [SerializeField]
    Sprite captainAndrew;

    [SerializeField]
    Sprite roboDrew;

    [SerializeField]
    Sprite bathroomsignDrew;

    [SerializeField]
    Sprite slaps;

    [SerializeField]
    Sprite doodleDrew;

    [SerializeField]
    Sprite mustache;

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
    GameObject slapsObject;

    [SerializeField]
    GameObject doodleDrewObject;

    [SerializeField]
    GameObject mustacheObject;

    [SerializeField]
    OutOfBoundsController outOfBoundsController1;

    [SerializeField]
    OutOfBoundsController outOfBoundsController2;

    [SerializeField]
    OutOfBoundsController outOfBoundsController3;

    [SerializeField]
    OutOfBoundsController outOfBoundsController4;

    public Action<GameObject> RemoveCharacterFromAIList;
    public Action<GameObject> RespawnCharacter;
    public Action<int> RemoveDamageTextAtIndex;

    void Start()
    {
        p1Lives = GameState.lives;
        p2Lives = GameState.lives;
        p3Lives = GameState.lives;
        p4Lives = GameState.lives;

        InitializeLivesForCharacter(p1Lives, p1LivesList, GameState.P1_Character);
        InitializeLivesForCharacter(p2Lives, p2LivesList, GameState.P2_Character);
        InitializeLivesForCharacter(p3Lives, p3LivesList, GameState.P3_Character);
        InitializeLivesForCharacter(p4Lives, p4LivesList, GameState.P4_Character);
    }

    void OnEnable()
    {
        outOfBoundsController1.RemoveLife += HandleRemoveLife;
        outOfBoundsController2.RemoveLife += HandleRemoveLife;
        outOfBoundsController3.RemoveLife += HandleRemoveLife;
        outOfBoundsController4.RemoveLife += HandleRemoveLife;
    }

    void OnDisable()
    {
        outOfBoundsController1.RemoveLife -= HandleRemoveLife;
        outOfBoundsController2.RemoveLife -= HandleRemoveLife;
        outOfBoundsController3.RemoveLife -= HandleRemoveLife;
        outOfBoundsController4.RemoveLife -= HandleRemoveLife;
    }

    void Update()
    {
        if(GameState.winners.Count == 1)
        {
            SceneManager.LoadSceneAsync("CelebrationScreen");
        }
    }

    void InitializeLivesForCharacter(int lives, List<GameObject> characterLives, GameState.Character character)
    {
        foreach(GameObject go in characterLives)
        {
            if (character == GameState.Character.AndyBear)
            {
                SetSprite(go, andyBear);
            }
            else if(character == GameState.Character.Oriam)
            {
                SetSprite(go, oriam);
            }
            else if (character == GameState.Character.Andrea)
            {
                SetSprite(go, andrea);
            }
            else if (character == GameState.Character.Pandrew)
            {
                SetSprite(go, pandrew);
            }
            else if (character == GameState.Character.RoboDrew)
            {
                SetSprite(go, roboDrew);
            }
            else if (character == GameState.Character.AndyAndi)
            {
                SetSprite(go, andyAndi);
            }
            else if (character == GameState.Character.AndyThug)
            {
                SetSprite(go, andyThug);
            }
            else if (character == GameState.Character.CaptainAndrew)
            {
                SetSprite(go, captainAndrew);
            }
            else if (character == GameState.Character.BathroomsignDrew)
            {
                SetSprite(go, bathroomsignDrew);
            }
            else if (character == GameState.Character.Slaps)
            {
                SetSprite(go, slaps);
            }
            else if (character == GameState.Character.DoodleDrew)
            {
                SetSprite(go, doodleDrew);
            }
            else if (character == GameState.Character.Mustache)
            {
                SetSprite(go, mustache);
            }

            go.SetActive(false);
        }

        for(int i = 0; i < lives; i++)
        {
            characterLives[i].SetActive(true);
        }
    }

    void SetSprite(GameObject go, Sprite sprite)
    {
        Image img = go.GetComponent<Image>();
        if(img != null)
        {
            img.sprite = sprite;
        }
    }

    void HandleRemoveLife(GameState.Character character)
    {
        if(character == GameState.P1_Character)
        {
            p1Lives--;

            if(p1Lives > 0)
            {
                p1LivesList[p1Lives].SetActive(false);
                GameObject newChar = GetGameObjectForCharacter(GameState.P1_Character);
                if(newChar != null)
                {
                    RespawnCharacter?.Invoke(newChar);
                }
            }
            else
            {
                p1LivesList[0].SetActive(false);
                RemoveCharacterFromAIList?.Invoke(GameState.P1);
                GameState.winners.Remove(GameState.P1_Character.ToString());
                RemoveDamageTextAtIndex?.Invoke(0);
            }
        }
        else if(character == GameState.P2_Character)
        {
            p2Lives--;

            if (p2Lives > 0)
            {
                p2LivesList[p2Lives].SetActive(false);
                GameObject newChar = GetGameObjectForCharacter(GameState.P2_Character);
                if (newChar != null)
                {
                    RespawnCharacter?.Invoke(newChar);
                }
            }
            else
            {
                p2LivesList[0].SetActive(false);
                RemoveCharacterFromAIList?.Invoke(GameState.P2);
                GameState.winners.Remove(GameState.P2_Character.ToString());
                RemoveDamageTextAtIndex?.Invoke(1);
            }
        }
        else if (character == GameState.P3_Character)
        {
            p3Lives--;

            if (p3Lives > 0)
            {
                p3LivesList[p3Lives].SetActive(false);
                GameObject newChar = GetGameObjectForCharacter(GameState.P3_Character);
                if (newChar != null)
                {
                    RespawnCharacter?.Invoke(newChar);
                }
            }
            else
            {
                p3LivesList[0].SetActive(false);
                RemoveCharacterFromAIList?.Invoke(GameState.P3);
                GameState.winners.Remove(GameState.P3_Character.ToString());
                RemoveDamageTextAtIndex?.Invoke(2);
            }
        }
        else if (character == GameState.P4_Character)
        {
            p4Lives--;

            if (p4Lives > 0)
            {
                p4LivesList[p4Lives].SetActive(false);
                GameObject newChar = GetGameObjectForCharacter(GameState.P4_Character);
                if (newChar != null)
                {
                    RespawnCharacter?.Invoke(newChar);
                }
            }
            else
            {
                p4LivesList[0].SetActive(false);
                RemoveCharacterFromAIList?.Invoke(GameState.P4);
                GameState.winners.Remove(GameState.P4_Character.ToString());
                RemoveDamageTextAtIndex?.Invoke(3);
            }
        }
    }

    private GameObject GetGameObjectForCharacter(GameState.Character character)
    {
        if(character == GameState.Character.AndyBear)
        {
            return andyBearObject;
        }
        else if(character == GameState.Character.Oriam)
        {
            return oriamObject;
        }
        else if(character == GameState.Character.Andrea)
        {
            return andreaObject;
        }
        else if(character == GameState.Character.Pandrew)
        {
            return pandrewObject;
        }
        else if(character == GameState.Character.RoboDrew)
        {
            return roboDrewObject;
        }
        else if(character == GameState.Character.AndyAndi)
        {
            return andyAndiObject;
        }
        else if(character == GameState.Character.AndyThug)
        {
            return andyThugObject;
        }
        else if(character == GameState.Character.CaptainAndrew)
        {
            return captainAndrewObject;
        }
        else if(character == GameState.Character.BathroomsignDrew)
        {
            return bathroomsignDrewObject;
        }
        else if (character == GameState.Character.Slaps)
        {
            return slapsObject;
        }
        else if (character == GameState.Character.DoodleDrew)
        {
            return doodleDrewObject;
        }
        else if (character == GameState.Character.Mustache)
        {
            return mustacheObject;
        }
        else
        {
            Debug.Log("Something is wrong....");
            return null;
        }
    }
}
