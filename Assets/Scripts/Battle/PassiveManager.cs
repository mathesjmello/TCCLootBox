using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace.Battle;
using UnityEngine;
using UnityEngine.UI;

public class PassiveManager : MonoBehaviour
{
    private PlayerStats _player;
    public Button passiveButton, closeButton;
    public List<GameObject> passivePainel;
    private int i, l;
    
    private Loot[] loots;

    private void Start()
    {
        passiveButton.onClick.AddListener(OpenPainel);
        closeButton.onClick.AddListener(ClosePainel);
    }

    private void ClosePainel()
    {
        passivePainel[i].SetActive(false);
        foreach (var loot in loots)
        {
            loot.botao.onClick.RemoveListener(Chose);
            loot.botao.onClick.AddListener(loot.SpendLoot);
        }
    }

    private void OpenPainel()
    {
        loots = FindObjectsOfType<Loot>();
        if (RoundManager.playerTurn)
        {
            _player = RoundManager.turnTeam.Peek().gameObject.GetComponent<PlayerStats>();
            i = _player.passivaIndex;
            passivePainel[i].SetActive(true);
            foreach (var loot in loots)
            {
                loot.botao.onClick.RemoveListener(loot.SpendLoot);
                loot.botao.onClick.AddListener(Chose);
            }
        }
        
    }

    private void Chose()
    {
        throw new NotImplementedException();
    }
}
