using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    private float speed;

    public float run_speed;
    public float walk_speed;

    // Start is called before the first frame update
    void Start()
    {
        speed = walk_speed;
    }

    // Update is called once per frame
    void Update()
    {
        PatrzNaMysz();

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            speed = run_speed;
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed = walk_speed;
        }

        if (Input.GetKey(KeyCode.W))
        {
            transform.position = new Vector2(transform.position.x, transform.position.y + speed);
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.position = new Vector2(transform.position.x - speed, transform.position.y);
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.position = new Vector2(transform.position.x, transform.position.y - speed);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.position = new Vector2(transform.position.x + speed, transform.position.y);
        }
    }

    public void PatrzNaMysz()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector2 direction = new Vector2(
            mousePosition.x - transform.position.x,
            mousePosition.y - transform.position.y);

        transform.up = direction;
    }
}
