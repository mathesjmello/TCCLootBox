using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace.Battle;
using UnityEngine;
using UnityEngine.UI;

public class PassiveManager : MonoBehaviour
{
    public GameObject PrefabLoots;
    public GameObject ChoseTransfom;
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
        var ClickCopy = Instantiate(PrefabLoots, ChoseTransfom.transform.position, Quaternion.identity, ChoseTransfom.transform);
        var CopyLoot = ClickCopy.GetComponent<Loot>();
        foreach (var loot in loots)
        {
            if (loot.Select)
            {
                CopyLoot.TypeLoot = loot.TypeLoot;
                CopyLoot._rarit = loot._rarit;
                CopyLoot.m_Image = loot.m_Image;
                CopyLoot.text = transform.GetChild(0);
                CopyLoot.text.GetComponent<Text>().text = loot.GetComponent<Text>().text;
            }
        }
    }
}
