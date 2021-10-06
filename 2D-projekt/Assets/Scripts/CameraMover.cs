using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMover : MonoBehaviour
{

    private Vector3 playerPos;
    private GameObject player;
    private Transform tr;
    private int page = 0; 


    private void Start()
    {
        player = GameObject.Find("Player");
        tr = gameObject.GetComponent<Transform>();
    }

    void Update()
    {
        playerPos = player.GetComponent<Transform>().position;

        if (playerPos.y > page*10 + 5)
        {
            tr.position = new Vector3(0, tr.position.y + 10, -30);
            page += 1;
        }
        else if (playerPos.y < page*10 - 5)
        {
            tr.position = new Vector3(0, tr.position.y - 10, -30);
            page -= 1;
        }
    }
}
