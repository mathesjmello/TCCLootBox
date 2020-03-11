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
    private Transform lastParent;
    private GameObject selectLoot;
    private Loot[] loots;
    public Passive Passiva;
    public bool FirstTime = true;
    public GameObject TutorialPainel;

    private void Start()
    {
        passiveButton.onClick.AddListener(OpenPainel);
        closeButton.onClick.AddListener(ClosePainel);
    }

    private void ClosePainel()
    {
        FirstTime = false;
        if(selectLoot)
        selectLoot.transform.parent = lastParent;
        passivePainel[i].SetActive(false);
        Passiva.CleanPainel();
        foreach (var loot in loots)
        {
            loot.botao.onClick.RemoveListener(loot.Chose);
            loot.botao.onClick.AddListener(loot.SpendLoot);
        }
    }

    private void OpenPainel()
    {
        if (FirstTime)
        {
            TutorialPainel.SetActive(true);
        }
        loots = FindObjectsOfType<Loot>();
        if (RoundManager.playerTurn)
        {
            _player = RoundManager.turnTeam.Peek().gameObject.GetComponent<PlayerStats>();
            i = _player.passivaIndex;
            passivePainel[i].SetActive(true);
            foreach (var loot in loots)
            {
                loot.botao.onClick.RemoveListener(loot.SpendLoot);
                loot.botao.onClick.AddListener(loot.Chose);
            }
        }
        
    }


    public void SelectLoot(GameObject o)
    {
        selectLoot = o;
        lastParent = o.transform.parent;
        o.transform.SetParent(passivePainel[i].GetComponent<Passive>().ChoseTransfom.transform, false); 
        o.transform.GetComponent<RectTransform>().anchoredPosition = new Vector2(101,-82);
        Passiva.CheckChange(o);
    }

    public void ChoseOne(Loot l)
    {
        
        var lootstats = selectLoot.GetComponent<Loot>();
        lootstats.SetValue(true, l._rarit, l.TypeLoot );
        ClosePainel();
    }
}
