using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerControler : MonoBehaviour
{
    private Vector2 targetPos;
    public float Yincrement;

    public float speed;
    public float maxHeight;
    public float minHeight;

    public int health = 3;

    public GameObject bombel_pierd;
    public float pierdnij_bomblem;

    public float timer1;

    // Start is called before the first frame update
    void Start()
    {
        targetPos = new Vector2(transform.position.x, transform.position.y);
        timer1 = 0;
    }

    // Update is called once per frame
    private void Update()
    {
        timer1 += Time.deltaTime;

        if (health <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        transform.position = Vector2.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.UpArrow) && transform.position.y < maxHeight)
        {
            Instantiate(bombel_pierd, transform.position, Quaternion.identity);
            targetPos = new Vector2(transform.position.x, transform.position.y + Yincrement);
            transform.position = targetPos;
            Instantiate(bombel_pierd, transform.position, Quaternion.identity);
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow) && transform.position.y > minHeight)
        {
            Instantiate(bombel_pierd, transform.position, Quaternion.identity);
            targetPos = new Vector2(transform.position.x, transform.position.y - Yincrement);
            transform.position = targetPos;
            Instantiate(bombel_pierd, transform.position, Quaternion.identity);
        }

        if(timer1 >= pierdnij_bomblem)
        {
            timer1 = 0;
            Instantiate(bombel_pierd, transform.position, Quaternion.identity);
        }
    }
}
