using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class ItemControl : MonoBehaviour
{
    public static event Action HandlePulled = delegate { };
    
    [SerializeField]
    private Text prizeText;
    [SerializeField]
    private Row[] rows;
    
    private int prizeValue;
    private bool resultsChecked = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!rows[0].rowStopped || !rows[1].rowStopped)
        {
        	prizeValue = 0;
        	prizeText.enable = false;
        	resultsChecked = false;
        }

        if (rows[0].rowStopped && rows[1].rowStopped)
    }
}
