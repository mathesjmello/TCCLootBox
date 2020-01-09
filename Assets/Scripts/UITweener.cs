using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UITweener : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
     	LeanTween.scale(gameObject, new Vector3(0,0,0), 0.5f).setOnComplete(DestroyMe);   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void DestroyMe()
    {
    	Destroy(gameObject);
    }
}
