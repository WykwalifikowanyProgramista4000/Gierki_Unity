using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPackControler : MonoBehaviour
{
    public int quantity;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.tag);
        Debug.Log(collision.name);

        if (collision.CompareTag("Player"))
        {
            PlayerControler gracz = collision.GetComponent<PlayerControler>();

            if(gracz != null)
            {
                gracz.AddAmmo(quantity);

                Destroy(gameObject);
            }
        }
    }
}
