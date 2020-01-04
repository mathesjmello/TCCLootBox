using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mission : MonoBehaviour
{
    public GameObject missao;
    public GameObject missao2;
    public GameObject missao0;

    // Start is called before the first frame update
    void Start()
    {
        missao0.SetActive(true);
        missao.SetActive(false);
        missao2.SetActive(false);


    }

    // Update is called once per frame
    void Update()
    {
        
        if (PlayerPrefs.GetInt("Missao") == 2)
        {
            missao0.SetActive(false);
            missao.SetActive(true);

        }
        if (PlayerPrefs.GetInt("SlimesMortos") == 3)
        {
            missao0.SetActive(false);

            missao.SetActive(false);

            missao2.SetActive(true);

        }
    }
}
