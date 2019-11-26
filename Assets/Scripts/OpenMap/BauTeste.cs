using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BauTeste : MonoBehaviour
{
    public string NextCenaName;
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
            PlayerPrefs.SetInt("indexSpam",2);
            PlayerPrefs.SetString("_sceneName", NextCenaName);
            Application.LoadLevel("LoadingScene");
            gameObject.SetActive(false);
        }
    }
}
