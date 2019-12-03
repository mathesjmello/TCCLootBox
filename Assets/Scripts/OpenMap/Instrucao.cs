using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instrucao : MonoBehaviour
{
    public GameObject Instru;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Instru == false ) 

        {
            PlayerPrefs.SetInt("Int",1);
        }
        if (PlayerPrefs.GetInt("Int") == 1)

        {
            Instru.SetActive(false);

        }

    }
    public void fechar()
    {
        PlayerPrefs.SetInt("Int", 1);
        Instru.SetActive(false);

    }
}
