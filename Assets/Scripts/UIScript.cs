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
   public Button GetItemBtn;
  
    void Start()
    {
     	// Teste do método pai (RandomItemGenerator)
     	GetItemBtn.onClick.AddListener(GetItem);
     	// Debug.Log(GetItemName());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void GetItem()
    {
      Debug.Log("FUNCIONOU PORRA");
      NameText.text = GetItemName();
      DescriptionText.text = "Your item " + GetItemDescription();
      PowerText.text = GetItemPower();
      DimensionText.text = GetItemDimension();
    }
}
