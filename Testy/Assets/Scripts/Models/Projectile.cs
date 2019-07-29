using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private float timer0;

    public float damage;
    public float strength = 20;
    public float bulletSpeed;
    public float lifespan;

    public Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateTimers();

        //transform.Translate(Vector2.up * bullet_speed * Time.deltaTime);
        rb.velocity = transform.up * bulletSpeed;

        if(timer0 >= lifespan)
        {
            Destroy(gameObject);
        }
    }

    private void UpdateTimers()
    {
        timer0 += Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("projectile has hit something!" + "\ntag: " + collision.tag + "\tname: " + collision.name);

        if (collision.CompareTag("Enemy"))
        {
            EnemyControler enemy = collision.GetComponent<EnemyControler>();
            if (enemy != null)
            {
                Vector2 direction = new Vector2(
                    enemy.transform.position.x - this.transform.position.x,
                    enemy.transform.position.y - this.transform.position.y);

                enemy.TakeDamage(damage);
                enemy.ThrowBack(direction, strength);
            }

            Destroy(gameObject);
        }
    }
}
