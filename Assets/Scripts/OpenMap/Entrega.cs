using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entrega : MonoBehaviour
{
    public GameObject Dialogo1;
    public int M;
    public GameObject Dialogo2;

    // Start is called before the first frame update
    void Start()
    {
        Dialogo1.SetActive(false);
        Dialogo2.SetActive(false);


    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.GetInt("Missao",0) == 0)
        {
            Dialogo1.SetActive(true);

        }

        if (PlayerPrefs.GetInt("SlimesMortos") == 3)
        {
            Dialogo2.SetActive(true);

        }
    }
}
