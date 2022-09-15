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

        transform.position = player.transform.position;
    }
}
