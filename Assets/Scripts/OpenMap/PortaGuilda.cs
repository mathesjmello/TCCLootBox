using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortaGuilda : MonoBehaviour
{
    public string NextCenaName;
    public bool Entrando = false;
    // Start is called before the first frame update
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
            if (Entrando == true)
            {
                PlayerPrefs.SetInt("indexSpam", 1);
                PlayerPrefs.SetString("_sceneName", NextCenaName);
                Application.LoadLevel("LoadingScene");
            }
            if (Entrando == false)
            {
                PlayerPrefs.SetString("_sceneName", NextCenaName);
                Application.LoadLevel("LoadingScene");
            }
        }
    }
}