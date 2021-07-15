using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CharacterSelectionController : MonoBehaviour
{
    [SerializeField]
    Texture2D cursorImage;

    [SerializeField]
    Texture2D cursorGrabImage;

    [SerializeField]
    Texture2D cursorPointImage;

    [SerializeField]
    IndicatorController p1IndicatorController;

    [SerializeField]
    IndicatorController p2IndicatorController;

    [SerializeField]
    IndicatorController p3IndicatorController;

    [SerializeField]
    IndicatorController p4IndicatorController;

    [SerializeField]
    List<CharacterImage> characterImagesList;

    bool isGrabbingP1Indicator;
    bool isGrabbingP2Indicator;
    bool isGrabbingP3Indicator;
    bool isGrabbingP4Indicator;

    [SerializeField]
    Image p1Image;

    [SerializeField]
    Image p2Image;

    [SerializeField]
    Image p3Image;

    [SerializeField]
    Image p4Image;

    [SerializeField]
    Sprite oriamSprite;

    [SerializeField]
    Sprite andyBearSprite;

    [SerializeField]
    Sprite andyThugSprite;

    [SerializeField]
    Sprite andyAndiSprite;

    [SerializeField]
    Sprite roboDrewSprite;

    [SerializeField]
    Sprite andreaSprite;

    [SerializeField]
    Sprite pandrewSprite;

    [SerializeField]
    Sprite captainAndrewSprite;

    [SerializeField]
    Sprite doodleDrewSprite;

    [SerializeField]
    Sprite bathroomsignDrewSprite;

    [SerializeField]
    Sprite mustacheSprite;

    [SerializeField]
    Sprite slapsSprite;

    [SerializeField]
    GameObject scrim;

    [SerializeField]
    Button startGameButton;

    GameState.Character tempCharacter;

    LoadingScreen loadingScreen;

    bool buttonSet = false;

    void Awake()
    {
        loadingScreen = GameObject.Find("LoadingCanvas").GetComponent<LoadingScreen>();

        if(loadingScreen != null)
        {
            loadingScreen.HideSpinner();
        }

        Cursor.SetCursor(cursorImage, Vector2.zero, CursorMode.Auto);

        p1Image.color = new Color(0, 0, 0, 0);
        p2Image.color = new Color(0, 0, 0, 0);
        p3Image.color = new Color(0, 0, 0, 0);
        p4Image.color = new Color(0, 0, 0, 0);
    }

    void OnEnable()
    {
        p1IndicatorController.IndicatorWasClicked += HandleUserClickedIndicatorP1;
        p2IndicatorController.IndicatorWasClicked += HandleUserClickedIndicatorP2;
        p3IndicatorController.IndicatorWasClicked += HandleUserClickedIndicatorP3;
        p4IndicatorController.IndicatorWasClicked += HandleUserClickedIndicatorP4;

        foreach(CharacterImage characterImage in characterImagesList)
        {
            characterImage.IndicatorOverCharacter += HandleIndicatorOverCharacter;
        }
    }

    void OnDisable()
    {
        p1IndicatorController.IndicatorWasClicked -= HandleUserClickedIndicatorP1;
        p2IndicatorController.IndicatorWasClicked -= HandleUserClickedIndicatorP2;
        p3IndicatorController.IndicatorWasClicked -= HandleUserClickedIndicatorP3;
        p4IndicatorController.IndicatorWasClicked -= HandleUserClickedIndicatorP4;

        foreach(CharacterImage characterImage in characterImagesList)
        {
            characterImage.IndicatorOverCharacter -= HandleIndicatorOverCharacter;
        }
    }

    void Update()
    {
        if(p1Image.color.a != 0 && p2Image.color.a != 0 && p3Image.color.a != 0 && p4Image.color.a != 0
            && !isGrabbingP1Indicator && !isGrabbingP2Indicator && !isGrabbingP3Indicator && !isGrabbingP4Indicator)
        {
            scrim.SetActive(true);
            Cursor.SetCursor(cursorPointImage, Vector2.zero, CursorMode.Auto);
            if(!buttonSet)
            {
                startGameButton.onClick.AddListener(HandleStartButtonClicked);
                buttonSet = true;
            }
        }
    }

    void HandleUserClickedIndicatorP1(bool isGrabbed)
    {
        HandleUserClickedIndicator(isGrabbed);

        if(isGrabbed)
        {
            isGrabbingP1Indicator = true;
            isGrabbingP2Indicator = false;
            isGrabbingP3Indicator = false;
            isGrabbingP4Indicator = false;
        }
        else
        {
            isGrabbingP1Indicator = false;
            isGrabbingP2Indicator = false;
            isGrabbingP3Indicator = false;
            isGrabbingP4Indicator = false;
        }
    }

    void HandleUserClickedIndicatorP2(bool isGrabbed)
    {
        HandleUserClickedIndicator(isGrabbed);

        if (isGrabbed)
        {
            isGrabbingP2Indicator = true;
            isGrabbingP1Indicator = false;
            isGrabbingP3Indicator = false;
            isGrabbingP4Indicator = false;
        }
        else
        {
            isGrabbingP1Indicator = false;
            isGrabbingP2Indicator = false;
            isGrabbingP3Indicator = false;
            isGrabbingP4Indicator = false;
        }
    }

    void HandleUserClickedIndicatorP3(bool isGrabbed)
    {
        HandleUserClickedIndicator(isGrabbed);

        if (isGrabbed)
        {
            isGrabbingP3Indicator = true;
            isGrabbingP2Indicator = false;
            isGrabbingP1Indicator = false;
            isGrabbingP4Indicator = false;
        }
        else
        {
            isGrabbingP1Indicator = false;
            isGrabbingP2Indicator = false;
            isGrabbingP3Indicator = false;
            isGrabbingP4Indicator = false;
        }
    }

    void HandleUserClickedIndicatorP4(bool isGrabbed)
    {
        HandleUserClickedIndicator(isGrabbed);

        if (isGrabbed)
        {
            isGrabbingP4Indicator = true;
            isGrabbingP2Indicator = false;
            isGrabbingP3Indicator = false;
            isGrabbingP1Indicator = false;
        }
        else
        {
            isGrabbingP1Indicator = false;
            isGrabbingP2Indicator = false;
            isGrabbingP3Indicator = false;
            isGrabbingP4Indicator = false;
        }
    }

    void HandleUserClickedIndicator(bool isGrabbed)
    {
        if(isGrabbed)
        {
            Cursor.SetCursor(cursorGrabImage, Vector2.zero, CursorMode.Auto);
        }
        else
        {
            Cursor.SetCursor(cursorImage, Vector2.zero, CursorMode.Auto);
        }
    }

    void HandleIndicatorOverCharacter(string name)
    {
        switch(name)
        {
            case "Oriam":
                SetImage(oriamSprite);
                tempCharacter = GameState.Character.Oriam;
                break;
            case "AndyBear":
                SetImage(andyBearSprite);
                tempCharacter = GameState.Character.AndyBear;
                break;
            case "AndyThug":
                SetImage(andyThugSprite);
                tempCharacter = GameState.Character.AndyThug;
                break;
            case "AndyAndi":
                SetImage(andyAndiSprite);
                tempCharacter = GameState.Character.AndyAndi;
                break;
            case "RoboDrew":
                SetImage(roboDrewSprite);
                tempCharacter = GameState.Character.RoboDrew;
                break;
            case "Andrea":
                SetImage(andreaSprite);
                tempCharacter = GameState.Character.Andrea;
                break;
            case "Pandrew":
                SetImage(pandrewSprite);
                tempCharacter = GameState.Character.Pandrew;
                break;
            case "CaptainAndrew":
                SetImage(captainAndrewSprite);
                tempCharacter = GameState.Character.CaptainAndrew;
                break;
            case "DoodleDrew":
                SetImage(doodleDrewSprite);
                tempCharacter = GameState.Character.DoodleDrew;
                break;
            case "Mustache":
                SetImage(mustacheSprite);
                tempCharacter = GameState.Character.Mustache;
                break;
            case "Slaps":
                SetImage(slapsSprite);
                tempCharacter = GameState.Character.Slaps;
                break;
            case "BathroomsignDrew":
                SetImage(bathroomsignDrewSprite);
                tempCharacter = GameState.Character.BathroomsignDrew;
                break;
            case "Reset":
                SetImage(null);
                tempCharacter = GameState.Character.None;
                break;
        }

        if(isGrabbingP1Indicator)
        {
            GameState.P1_Character = tempCharacter;
        }
        else if(isGrabbingP2Indicator)
        {
            GameState.P2_Character = tempCharacter;
        }
        else if (isGrabbingP3Indicator)
        {
            GameState.P3_Character = tempCharacter;
        }
        else if (isGrabbingP4Indicator)
        {
            GameState.P4_Character = tempCharacter;
        }
    }

    void SetImage(Sprite image)
    {
        if(isGrabbingP1Indicator)
        {
            p1Image.sprite = image;

            if(image == null)
            {
                p1Image.color = new Color(0, 0, 0, 0);
            }
            else
            {
                p1Image.color = new Color(255, 255, 255, 255);
            }
        }
        else if(isGrabbingP2Indicator)
        {
            p2Image.sprite = image;

            if (image == null)
            {
                p2Image.color = new Color(0, 0, 0, 0);
            }
            else
            {
                p2Image.color = new Color(255, 255, 255, 255);
            }
        }
        else if(isGrabbingP3Indicator)
        {
            p3Image.sprite = image;

            if (image == null)
            {
                p3Image.color = new Color(0, 0, 0, 0);
            }
            else
            {
                p3Image.color = new Color(255, 255, 255, 255);
            }
        }
        else if(isGrabbingP4Indicator)
        {
            p4Image.sprite = image;

            if (image == null)
            {
                p4Image.color = new Color(0, 0, 0, 0);
            }
            else
            {
                p4Image.color = new Color(255, 255, 255, 255);
            }
        }
    }

    void HandleStartButtonClicked()
    {
        if(loadingScreen != null)
        {
            loadingScreen.ShowSpinner();
        }

        SceneManager.LoadSceneAsync("SelectStage");
    }
}
