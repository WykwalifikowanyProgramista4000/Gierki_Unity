using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KieleckiSloik : MonoBehaviour
{
    public int points = 1;
    public GameObject collectEffect;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            collision.GetComponent<PlayerControler>().AddPoints(points);

            Instantiate(collectEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
