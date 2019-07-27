using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControler : MonoBehaviour
{
    public float speed;
    public float throwBack;

    public GameObject player_character;
    public float lineOfSight;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (SpotPlayer())
        {
            LookAtPlayer();
            MoveForward();
        }
    }
    
    //Death
    public void Die()
    {
        Destroy(gameObject);
    }

    public bool SpotPlayer()
    {
        Vector2 distance = new Vector2(
            player_character.transform.position.x - transform.position.x,
            player_character.transform.position.y - transform.position.y);

        return (distance.magnitude <= lineOfSight) ? true : false;

    }
    public void LookAtPlayer()
    {
        if(player_character != null)
        {
            Vector2 direction = new Vector2(
            player_character.transform.position.x - transform.position.x,
            player_character.transform.position.y - transform.position.y);

            transform.up = direction;
        }
    }

    public void MoveForward()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            Vector2 direction = new Vector2(
            transform.position.x - player_character.transform.position.x,
            transform.position.y - player_character.transform.position.y);

            ThrowBack(direction);
            player_character.GetComponent<PlayerControler>().ThrowBack(direction * -1);
            player_character.GetComponent<PlayerControler>().health--;
        }
    }

    public void ThrowBack(Vector2 direction)
    {
        gameObject.GetComponent<Rigidbody2D>().velocity = direction * throwBack;
    }
}
