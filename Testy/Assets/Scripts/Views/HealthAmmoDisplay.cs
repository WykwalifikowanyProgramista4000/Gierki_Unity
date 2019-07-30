using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class HealthAmmoDisplay : MonoBehaviour
{
    public Text playerParamsText;
    public GameObject player_character;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(player_character != null)
        {
            playerParamsText.text =
                "Points :: " + player_character.GetComponent<PlayerControler>().points +
                "\nHealth :: " + player_character.GetComponent<PlayerControler>().health +
                "\nAmmo :: " + player_character.GetComponentInChildren<WeaponControler>().ammo;

            if (Input.GetKeyDown(KeyCode.Space)) { player_character.GetComponent<PlayerControler>().health--; }
        }
    }
}
