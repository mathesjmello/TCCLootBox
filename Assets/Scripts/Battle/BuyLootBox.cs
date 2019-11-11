using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyLootBox : MonoBehaviour
{
    private int _currentGold = 3;
 
    public GameObject PainelLootBox;
    public GameObject LootBoxPrefab;
    public Button BuyButton, SkipButton;

    public Text GoldText;
    
    
    public int Gold
    {
        get { return _currentGold;}
        set
        {
            if (value<_currentGold)
            {
                if (_currentGold > 0)
                {           
                    var newLootbox = Instantiate(LootBoxPrefab,Vector3.zero,Quaternion.identity,PainelLootBox.transform);
                    _currentGold = value;
                    GoldText.text = _currentGold.ToString();
                }
            }
            else
            {
                _currentGold = value;
                GoldText.text = _currentGold.ToString();
                RoundManager.EndTurn();
            }
            
            
        } 
    }
    // Start is called before the first frame update
    void Start()
    {
        SkipButton.onClick.AddListener(SkipTurn);
        BuyButton.onClick.AddListener(CreateLootBox);
        GoldText.text = _currentGold.ToString();
    }

    private void SkipTurn()
    {
        Gold++;
        
    }

    private void CreateLootBox()
    {
        Gold--;
    }

}
