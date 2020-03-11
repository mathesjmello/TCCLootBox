using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleTutorial : MonoBehaviour
{
    public GameObject Tutorial1;

    public GameObject TutorialPassiva;
    // Start is called before the first frame update
    private void Start()
    
    {
        if (PlayerPrefs.GetFloat("Tutorial") < 1)
        {
            Time.timeScale = 0;
            StartTutorial();
        }
        else
        {
            EndTutorial();
        }
        
    }

    private void StartTutorial()
    {
        Tutorial1.SetActive(true);
    }

    public void EndTutorial()
    {
        Time.timeScale = 1;
        PlayerPrefs.SetFloat("Tutorial",1);
        Persistence.SaveData();
    }
    
}
