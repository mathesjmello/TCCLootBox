using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vitoria : MonoBehaviour
{
    public string NextCenaName;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerPrefs.GetInt("Missao") == 3)
        {
            PlayerPrefs.SetInt("Missao", 0);
            PlayerPrefs.SetInt("Monstro1", 0);
            PlayerPrefs.SetInt("Monstro2", 0);
            PlayerPrefs.SetInt("Monstro3", 0);

            PlayerPrefs.SetInt("SlimesMortos", 0);
            PlayerPrefs.SetInt("indexSpam", 0);
            PlayerPrefs.SetString("_sceneName", NextCenaName);
            Application.LoadLevel("LoadingScene");
        }
    }
}
