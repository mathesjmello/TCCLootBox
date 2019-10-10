using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : TaticsMove
{
    // Start is called before the first frame update
    void Start()
    {
     	Init();   
    }

    // Update is called once per frame
    void Update()
    {
    	FindSelectableTiles();
    }
}
