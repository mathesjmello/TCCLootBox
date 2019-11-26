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
            PlayerPrefs.DeleteAll();
            PlayerPrefs.SetString("_sceneName", NextCenaName);
            Application.LoadLevel("LoadingScene");
        }
    }
}
