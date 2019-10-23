using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BauTeste : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter(Collider theCollision) // C#, type first, name in second
    {
        if (theCollision.gameObject.tag == "Player")
        // By using {}, the condition apply to that entire scope, instead of the next line.
        {
            Application.LoadLevel("TacticsMovement");

        }
    }
}
