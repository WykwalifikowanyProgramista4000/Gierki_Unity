using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Szczelacz : MonoBehaviour
{

    public GameObject pocisk;
    public GameObject pierdolniecie;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Pierdolnij();
        }
    }

    public void Pierdolnij()
    {
        Instantiate(pocisk, transform.position, transform.parent.rotation);
        Instantiate(pierdolniecie, transform.position, transform.parent.rotation);
    }
}
