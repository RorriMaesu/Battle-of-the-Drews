using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CelebrationController : MonoBehaviour
{
    [SerializeField]
    GameObject oneWinner;

    [SerializeField]
    GameObject twoWinners;

    [SerializeField]
    GameObject threeWinners;

    [SerializeField]
    GameObject fourWinners;

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

    Dictionary<string, Sprite> nameToSpriteMapping = new Dictionary<string, Sprite>();

    [SerializeField]
    List<GameObject> oneWinnerObjects;

    [SerializeField]
    List<GameObject> twoWinnersObjects;

    [SerializeField]
    List<GameObject> threeWinnersObjects;

    [SerializeField]
    List<GameObject> fourWinnersObjects;

    [SerializeField]
    TMPro.TextMeshProUGUI text;

    void OnEnable()
    {
        oneWinner.SetActive(false);
        twoWinners.SetActive(false);
        threeWinners.SetActive(false);
        fourWinners.SetActive(false);

        nameToSpriteMapping.Add("BathroomsignDrew", bathroomsignDrew);
        nameToSpriteMapping.Add("Slaps", slaps);
        nameToSpriteMapping.Add("DoodleDrew", doodleDrew);
        nameToSpriteMapping.Add("Mustache", mustache);
        nameToSpriteMapping.Add("AndyBear", andyBear);
        nameToSpriteMapping.Add("Oriam", oriam);
        nameToSpriteMapping.Add("Pandrew", pandrew);
        nameToSpriteMapping.Add("RoboDrew", roboDrew);
        nameToSpriteMapping.Add("AndyAndi", andyAndi);
        nameToSpriteMapping.Add("AndyThug", andyThug);
        nameToSpriteMapping.Add("Andrea", andrea);
        nameToSpriteMapping.Add("CaptainAndrew", captainAndrew);

        if(GameState.winners.Count == 1)
        {
            oneWinner.SetActive(true);
            text.text = GameState.winners[0] + " Wins!";

            SpriteRenderer spriteRenderer = oneWinnerObjects[0].GetComponent<SpriteRenderer>();
            if(spriteRenderer != null)
            {
                spriteRenderer.sprite = nameToSpriteMapping[GameState.winners[0]];
            }
        }
        else if(GameState.winners.Count == 2)
        {
            twoWinners.SetActive(true);

            text.text = GameState.winners[0] + " and " + GameState.winners[1] + " Win! ";

            //Character 1

            SpriteRenderer spriteRenderer = twoWinnersObjects[0].GetComponent<SpriteRenderer>();
            if(spriteRenderer != null)
            {
                spriteRenderer.sprite = nameToSpriteMapping[GameState.winners[0]];
            }

            //Character 2

            SpriteRenderer spriteRenderer1 = twoWinnersObjects[1].GetComponent<SpriteRenderer>();
            if(spriteRenderer1 != null)
            {
                spriteRenderer1.sprite = nameToSpriteMapping[GameState.winners[1]];
            }
        }
        else if(GameState.winners.Count == 3)
        {
            threeWinners.SetActive(true);

            text.text = GameState.winners[0] + ", " + GameState.winners[1] + " and " + GameState.winners[2] + " Win! ";

            //Character 1
            SpriteRenderer spriteRenderer = threeWinnersObjects[0].GetComponent<SpriteRenderer>();
            if(spriteRenderer != null)
            {
                spriteRenderer.sprite = nameToSpriteMapping[GameState.winners[0]];
            }

            //Character 2
            SpriteRenderer spriteRenderer1 = threeWinnersObjects[1].GetComponent<SpriteRenderer>();
            if(spriteRenderer1 != null)
            {
                spriteRenderer1.sprite = nameToSpriteMapping[GameState.winners[1]];
            }

            //Character 3
            SpriteRenderer spriteRenderer2 = threeWinnersObjects[2].GetComponent<SpriteRenderer>();
            if(spriteRenderer2 != null)
            {
                spriteRenderer2.sprite = nameToSpriteMapping[GameState.winners[2]];
            }
        }
        else if(GameState.winners.Count == 4)
        {
            fourWinners.SetActive(true);

            text.text = GameState.winners[0] + ", " + GameState.winners[1] + ", " + GameState.winners[2] + " and " + GameState.winners[3] + " Win! ";

            //Character 1
            SpriteRenderer spriteRenderer = fourWinnersObjects[0].GetComponent<SpriteRenderer>();
            if (spriteRenderer != null)
            {
                spriteRenderer.sprite = nameToSpriteMapping[GameState.winners[0]];
            }

            //Character 2
            SpriteRenderer spriteRenderer1 = fourWinnersObjects[1].GetComponent<SpriteRenderer>();
            if (spriteRenderer1 != null)
            {
                spriteRenderer1.sprite = nameToSpriteMapping[GameState.winners[1]];
            }

            //Character 3
            SpriteRenderer spriteRenderer2 = fourWinnersObjects[2].GetComponent<SpriteRenderer>();
            if (spriteRenderer2 != null)
            {
                spriteRenderer2.sprite = nameToSpriteMapping[GameState.winners[2]];
            }

            //Character 4
            SpriteRenderer spriteRenderer3 = fourWinnersObjects[3].GetComponent<SpriteRenderer>();
            if(spriteRenderer3 != null)
            {
                spriteRenderer3.sprite = nameToSpriteMapping[GameState.winners[3]];
            }
        }
    }
}
