using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mission : MonoBehaviour
{
    public GameObject missao;
    public GameObject missao2;

    // Start is called before the first frame update
    void Start()
    {
        missao.SetActive(false);
        missao2.SetActive(false);


    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.GetInt("Missao") == 2)
        {
            missao.SetActive(true);

        }
        if (PlayerPrefs.GetInt("SlimesMortos") == 3)
        {
            missao.SetActive(false);

            missao2.SetActive(true);

        }
    }
}
