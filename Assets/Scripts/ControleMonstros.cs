using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControleMonstros : MonoBehaviour
{
    public GameObject Slime1;
    public GameObject Slime2;
    public GameObject Slime3;

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetInt("ConversaMonstros") == 0)
        {
            Slime1.SetActive(false);
            Slime2.SetActive(false);
            Slime3.SetActive(false);

        }
        if (PlayerPrefs.GetInt("ConversaMonstros") == 1)
        {
            Slime1.SetActive(true);
            Slime2.SetActive(true);
            Slime3.SetActive(true);

        }

    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.GetInt("Monstro1") == 1)
        {
            Slime1.SetActive(false);

        }
        if (PlayerPrefs.GetInt("Monstro2") == 1)
        {
            Slime2.SetActive(false);

        }
        if (PlayerPrefs.GetInt("Monstro3") == 1)
        {
            Slime3.SetActive(false);

        }
    }
}
