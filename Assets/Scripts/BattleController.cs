using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleController : MonoBehaviour
{
    [SerializeField]
    TMPro.TextMeshProUGUI damage1;

    [SerializeField]
    TMPro.TextMeshProUGUI damage2;

    [SerializeField]
    TMPro.TextMeshProUGUI damage3;

    [SerializeField]
    TMPro.TextMeshProUGUI damage4;

    [SerializeField]
    List<TMPro.TextMeshProUGUI> damages = new List<TMPro.TextMeshProUGUI>();

    public List<GameObject> characters;

    [SerializeField]
    LivesController livesController;

    void Start()
    {
        characters = new List<GameObject>();

        characters.Add(GameState.P1);
        characters.Add(GameState.P2);
        characters.Add(GameState.P3);
        characters.Add(GameState.P4);

        damages.Add(damage1);
        damages.Add(damage2);
        damages.Add(damage3);
        damages.Add(damage4);

        damage1.text = 0.ToString() + "%";
        damage2.text = 0.ToString() + "%";
        damage3.text = 0.ToString() + "%";
        damage4.text = 0.ToString() + "%";

        foreach(GameObject character in characters)
        {
            DamageResolver dmgResolver = character.GetComponent<DamageResolver>();
            if(dmgResolver != null)
            {
                dmgResolver.DoDamage += HandleApplyDamage;
            }
        }
    }

    void OnEnable()
    {
        livesController.RemoveDamageTextAtIndex += HandleRemoveDamageAtIndex;
    }

    void OnDisable()
    {
        livesController.RemoveDamageTextAtIndex -= HandleRemoveDamageAtIndex;
    }

    void HandleRemoveDamageAtIndex(int index)
    {
        damages[index].color = new Color(0, 0, 0, 0);
    }

    public void HandleApplyDamage(GameObject go, int dmg)
    {
        characters[0] = GameObject.Find(GameState.P1_Character.ToString());
        characters[1] = GameObject.Find(GameState.P2_Character.ToString());
        characters[2] = GameObject.Find(GameState.P3_Character.ToString());
        characters[3] = GameObject.Find(GameState.P4_Character.ToString());

        foreach(GameObject character in characters)
        {
            if(character == null || go == null)
            {
                return;
            }

            if(character.name == go.name)
            {
                int index = characters.IndexOf(character);
                int damageAmount = int.Parse(damages[index].text.TrimEnd('%')) + dmg;
                damages[index].text = (damageAmount + dmg).ToString() + "%";

                if(damageAmount > 300)
                {
                    damages[index].color = Color.red;
                }
                else if(damageAmount > 200)
                {
                    damages[index].color = Color.yellow;
                }
                else if(damageAmount > 100)
                {
                    damages[index].color = Color.grey;
                }

                Rigidbody rigidbody = go.GetComponent<Rigidbody>();
                rigidbody.AddForce(new Vector3(dmg / 15, dmg / 15, 0), ForceMode.Impulse);
            }
        }
    }

    public void ResetDamageAtPosition(int pos)
    {
        damages[pos].color = Color.white;
        damages[pos].text = 0.ToString() + "%";

        if(pos == 0)
        {
            characters[pos] = GameObject.Find(GameState.P1_Character.ToString());
        }
        else if(pos == 1)
        {
            characters[pos] = GameObject.Find(GameState.P2_Character.ToString());
        }
        else if (pos == 2)
        {
            characters[pos] = GameObject.Find(GameState.P3_Character.ToString());
        }
        else if (pos == 3)
        {
            characters[pos] = GameObject.Find(GameState.P4_Character.ToString());
        }

        if(characters[pos] != null)
        {
            DamageResolver dmgResolver = characters[pos].GetComponent<DamageResolver>();
            if(dmgResolver != null)
            {
                dmgResolver.DoDamage += HandleApplyDamage;
            }
        }
    }

}
