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

   private ulong lastClickBtn;
  
    void Start()
    {	
      RandomItemBtn.onClick.AddListener(GetItem);
     	// Debug.Log(GetItemName());
      lastClickBtn = ulong.Parse(PlayerPrefs.GetString("lastClickBtn"));
    }

    // Update is called once per frame
    void Update()
    {
      if (!RandomItemBtn.IsInteractable())
      {
        ulong difference = ((ulong)System.DateTime.Now.Ticks - lastClickBtn);
        // Debug.Log(System.DateTime.Now.Ticks);
      }   
    }

    private void GetItem()
    {
      NameText.text = "Character Name: " + GetItemName();
      DescriptionText.text = "Your item " + GetItemDescription();
      PowerText.text = "Power: " + GetItemPower();
      DimensionText.text = "Round: " + GetItemDimension();
    }

    public void BtnClick() {
      lastClickBtn = (ulong)System.DateTime.Now.Ticks;
      // PlayerPrefs.SetString("lastClickBtn", lastClickBtn.ToString());
      RandomItemBtn.interactable = false;
    }
}
