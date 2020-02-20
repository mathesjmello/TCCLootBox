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

    private void Start()
    {
        passiveButton.onClick.AddListener(OpenPainel);
        closeButton.onClick.AddListener(ClosePainel);
    }

    private void ClosePainel()
    {
        passivePainel[i].SetActive(false);
    }

    private void OpenPainel()
    {
        if (RoundManager.playerTurn)
        {
            _player = RoundManager.turnTeam.Peek().gameObject.GetComponent<PlayerStats>();
            i = _player.passivaIndex;
        }
        passivePainel[i].SetActive(true);
    }
}
