using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : MonoBehaviour
{
    public int Monstros;
    public string NextCenaName;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D theCollision) // C#, type first, name in second
    {
        if (theCollision.gameObject.tag == "Player")
        {
            if (Monstros == 1)
            {
                PlayerPrefs.SetInt("Monstro1", 1);
                PlayerPrefs.SetInt("indexSpam", 2);

                PlayerPrefs.SetInt("indexSpam", Monstros);
                PlayerPrefs.SetString("_sceneName", NextCenaName);
                Application.LoadLevel("LoadingScene");

            }
            if (Monstros == 2)
            {
                PlayerPrefs.SetInt("Monstro2", 1);
                PlayerPrefs.SetInt("indexSpam", 3);

                PlayerPrefs.SetInt("indexSpam", Monstros);
                PlayerPrefs.SetString("_sceneName", NextCenaName);
                Application.LoadLevel("LoadingScene");
            }
            if (Monstros == 3)
            {
                PlayerPrefs.SetInt("Monstro3", 1);
                PlayerPrefs.SetInt("indexSpam", 4);

                PlayerPrefs.SetInt("indexSpam", Monstros);
                PlayerPrefs.SetString("_sceneName", NextCenaName);
                Application.LoadLevel("LoadingScene");
            }
        }
    }
}
