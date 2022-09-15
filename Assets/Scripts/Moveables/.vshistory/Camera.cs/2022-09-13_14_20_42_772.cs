using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    private GameObject player;

    public Vector3 pos;

    void Start()
    {
        player = GameObject.Find("Player");
    }

    void Update()
    {
        pos = new Vector3(player.transform.position.x, 3f, player.transform.position.z);
        transform.position = pos;
    }
}
