using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Row : MonoBehaviour
{
    private int randomValue;
    private float timeInterval;

    public bool rowStopped;
    public string stoppedSlot;
    // Start is called before the first frame update
    void Start()
    {
        rowStopped = true;
        GameControl.HandlePulled += StartRotating;
    }

    // Update is called once per frame
    private void StartRotating()
    {
    	stoppedSlot = "";
    	StartCoroutine("Rotate");
    }

    private IEnumerator Rotate()
    {
    	rowStopped = false;
    	timeInterval = 0.025f;

    	for (int i = 0; i < 30; i++){
    		if (transform.position.y <= -3.5f)
    		{
    			transform.position = new Vector2(transform.position.x, 1.75f);
    		}

    		transform.position = new Vector2(transform.position.x, transform.position.y - 0.25f);
    	}
    }
    void Update()
    {
        
    }
}
