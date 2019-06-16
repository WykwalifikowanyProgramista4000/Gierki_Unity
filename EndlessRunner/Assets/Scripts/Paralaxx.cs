using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Paralaxx : MonoBehaviour
{
    public float Speed = 22;
    public float end_position;
    public float restart_position;

    private void Start()
    {
        if(transform.rotation.z != 0) { Speed *= -1; }
    }
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * Speed * Time.deltaTime);

        if(transform.position.x <= end_position)
        {
            transform.position = new Vector3(restart_position, transform.position.y, transform.position.z);
        }
    }
}
