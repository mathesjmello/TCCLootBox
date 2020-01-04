using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentCharacter : MonoBehaviour
{
    public float Speed = 1f;


    Rigidbody2D Body;
    IsometricCharacterRenderer isoRenderer;

    private void Awake()
    {
        Body = GetComponent<Rigidbody2D>();
        isoRenderer = GetComponentInChildren<IsometricCharacterRenderer>();

    }


    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 Posit = Body.position;
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector2 inputVector = new Vector2(horizontalInput, verticalInput);
        inputVector = Vector2.ClampMagnitude(inputVector, 1);
        Vector2 movement = inputVector * Speed;
        Vector2 newPos = Posit + movement * Time.fixedDeltaTime;
        isoRenderer.SetDirection(movement);
        Body.MovePosition(newPos);
    }
}
