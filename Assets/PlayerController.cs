using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
    
    public float Velocity = 5;

    private Vector2 _input;

    private float _angle;
    
    public float horizontalSpeed = 2.0F;
    public float verticalSpeed = 2.0F;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetInput();

        Roteta();
        
        Move();

    }

    private void Roteta()
    {
        
        float h = horizontalSpeed * Input. GetAxis("Mouse X");
       
        transform.Rotate(0, h, 0);
    }

    private void Move()
    {
        if (Mathf.Abs(_input.x) > 0)
        {
            if (Input.GetKey(KeyCode.W))
            {
                transform.position += transform.forward * Velocity * Time.deltaTime;
            }

            if (Input.GetKey(KeyCode.S))
            {
                transform.position += transform.forward * -Velocity * Time.deltaTime;
            }

        }

        if (Mathf.Abs(_input.y)>0)
            
        {
            if (Input.GetKey(KeyCode.D))
            {
                transform.position += transform.right * Velocity * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.A))
            {
                transform.position += transform.right * -Velocity * Time.deltaTime;
            }
            
        }
        
    }

    private void GetInput()
    {
        _input.x = Input.GetAxisRaw("Vertical");
        _input.y = Input.GetAxisRaw("Horizontal");
    }
}
