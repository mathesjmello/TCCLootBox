using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScript : RandomItemGenerator
{
	 public Text NameText;
   public Text DescriptionText;
   public Text PowerText;
   public Text DimensionText;
   public Button GetItem;
    // Start is called before the first frame update
    void Start()
    {
     	// Teste do método pai (RandomItemGenerator)
     	GetItem.onClick.AddListener(GetItem);
     	// Debug.Log(GetItemName());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void GetItem()
    {
        NameText.text = 
    }
}
