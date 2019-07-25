using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponControler : MonoBehaviour
{

    public GameObject projectile;
    public GameObject shootEffect;

    public int ammo;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Shooting
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Pierdolnij();
        }
    }

    public void Pierdolnij()
    {
        //decreases amount of ammo
        if(ammo > 0)
        {
            ammo--;

            //Fast moving bullet
            Instantiate(projectile, transform.position, transform.parent.rotation);

            //Shooting effect
            Instantiate(shootEffect, transform.position, transform.parent.rotation);
        }

        
    }
}
