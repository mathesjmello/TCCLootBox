﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScript : RandomItemGenerator
{
	 public Text itemNameText;
   public Text itemDescriptionText;
    // Start is called before the first frame update
    void Start()
    {
     	// Teste do método pai (RandomItemGenerator)
     	Debug.Log(GetItemName());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
