using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour {

    public GameObject player;



    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(player.transform.position.x, 0, -10);
        if (player.transform.position.y > 0)
        {
            transform.position = new Vector3(player.transform.position.x, player.transform.position.y, -10);
        }
    }
}
