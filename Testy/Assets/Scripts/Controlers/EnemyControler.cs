using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControler : MonoBehaviour
{
    public float turnRate;
    public float speed;

    public GameObject player_character;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        LookAtPlayer();
        FollowPlayer();
    }

    void Turn()
    {
        transform.Rotate(Vector3.forward, turnRate * Time.deltaTime);
        transform.Translate(Vector2.up * speed * Time.deltaTime);
    }

    public void Die()
    {
        Destroy(gameObject);
    }

    public void LookAtPlayer()
    {
        Vector2 direction = new Vector2(
            player_character.transform.position.x - transform.position.x,
            player_character.transform.position.y - transform.position.y);

        transform.up = direction;
    }

    public void FollowPlayer()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime);
    }

}
