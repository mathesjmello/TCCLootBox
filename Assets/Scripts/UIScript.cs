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
   public Button RandomItemBtn;
  
    void Start()
    {
     	// Teste do método pai (RandomItemGenerator)
     	RandomItemBtn.onClick.AddListener(GetItem);
     	// Debug.Log(GetItemName());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void GetItem()
    {
      NameText.text = "Character Name: " + GetItemName();
      DescriptionText.text = "Your item " + GetItemDescription();
      PowerText.text = "Power: " + GetItemPower();
      DimensionText.text = "Round: " + GetItemDimension();
    }
}
