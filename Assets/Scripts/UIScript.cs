using System;
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
      lastClickBtn = ulong.Parse(PlayerPrefs.GetString("LastClickBtn"));
    }

    // Update is called once per frame
    void Update()
    {
      if (!RandomItemBtn.IsInteractable())
      {
        ulong difference = ((ulong)DateTime.Now.Ticks - lastClickBtn);
        ulong minutes = difference / TimeSpan.TicksPerMillisecond;
        // Debug.Log(DateTime.Now.Ticks);
        float secondsLeft = (float)(3000.0f - minutes) / 1000.0f;

        if (secondsLeft < 0)
        {
          RandomItemBtn.interactable = true;
          return;
        }
      }   
    }

    private void GetItem()
    {
      NameText.text = "Character Name: " + GetItemName();
      DescriptionText.text = "Your item " + GetItemDescription();
      PowerText.text = "Power: " + GetItemPower();
      DimensionText.text = "Round: " + GetItemDimension();

      lastClickBtn = (ulong)DateTime.Now.Ticks;
      PlayerPrefs.SetString("LastClickBtn", lastClickBtn.ToString());
      // PlayerPrefs.SetString("lastClickBtn", DateTime.Now.Ticks.ToString());
      RandomItemBtn.interactable = false;
    }

}
