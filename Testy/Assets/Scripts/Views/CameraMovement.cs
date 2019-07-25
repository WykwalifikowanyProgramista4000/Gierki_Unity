using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public GameObject player_character;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(player_character.transform.position.x, 
                                         player_character.transform.position.y,
                                         transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(player_character.transform.position.x,
                                         player_character.transform.position.y,
                                         transform.position.z);
    }
}
