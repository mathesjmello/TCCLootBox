using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControleMonstros : MonoBehaviour
{
    public GameObject Slime1;
    public GameObject Slime2;
    public GameObject Bruxa;
    public GameObject Gatos;
    public GameObject EventoMorteSlime;




    // Start is called before the first frame update
    void Start()
    {    
            Slime1.SetActive(false);
            Slime2.SetActive(false);

        if (PlayerPrefs.GetInt("Missao") == 1)
        {
            if (PlayerPrefs.GetInt("Monstro1") == 0)
            {
                Slime1.SetActive(true);
            }
            if (PlayerPrefs.GetInt("Monstro2") == 0)
            {
                Slime2.SetActive(true);
            }
            
        }
        if (PlayerPrefs.GetInt("Missao") == 2)
        {
            if (PlayerPrefs.GetInt("Bruxa") == 0)
            {
                Slime1.SetActive(true);
            }
            if (PlayerPrefs.GetInt("Gatos") == 0)
            {
                Slime2.SetActive(true);
            }
            
        }

    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerPrefs.GetInt("Monstro1") == 1 && PlayerPrefs.GetInt("Monstro2") == 1)
        {
            PlayerPrefs.SetInt("DialogoGuilda", 3);
            EventoMorteSlime.SetActive(true);

        }

    }
}
