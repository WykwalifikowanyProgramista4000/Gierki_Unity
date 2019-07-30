using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    private float speed;
    public int health = 3;
    public int points = 0;
    public float runSpeed = 0.6f;
    public float walkSpeed = 0.3f;
    public float throwBack;

    public GameObject uiCanvas;
    public GameObject deathScreen;

    // Start is called before the first frame update
    void Start()
    {
        speed = walkSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        //Player rotation
        LookAtCoursor();

        //Movement modes
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            speed = runSpeed;
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed = walkSpeed;
        }

        //Walking around the map
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

        //Is player dead?
        if(health <= 0)
        {
            health = 0;
            Die();
        }
    }

    public void LookAtCoursor()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector2 direction = new Vector2(
            mousePosition.x - transform.position.x,
            mousePosition.y - transform.position.y);

        transform.up = direction;
    }

    public void AddAmmo(int quantity)
    {
        WeaponControler weapon = gameObject.GetComponentInChildren<WeaponControler>();

        if(weapon != null)
        {
            weapon.ammo += quantity;
        }
        
    }

    public void AddHealth(int quantity)
    {
        health += quantity;
    }

    public void AddPoints(int quantity)
    {
        points += quantity;
    }

    private void Die()
    {
        Instantiate(deathScreen, uiCanvas.transform);
        Destroy(gameObject);
    }

    public void ThrowBack(Vector2 direction)
    {
        gameObject.GetComponent<Rigidbody2D>().velocity = direction * throwBack;
    }
}
