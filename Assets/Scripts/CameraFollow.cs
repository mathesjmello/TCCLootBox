using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform Player;
    public float delay = 0.4f;

    private Vector3 cameraPos;

    private Vector3 velocity = Vector3.zero;

   

    void Update()
    {
        cameraPos = new Vector3(Player.position.x, Player.position.y, -10f);
        transform.position = Vector3.SmoothDamp(gameObject.transform.position, cameraPos, ref velocity, delay);
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -12.5f, 14.5f), Mathf.Clamp(transform.position.y, -21f, 11f), transform.position.z);
    }
}