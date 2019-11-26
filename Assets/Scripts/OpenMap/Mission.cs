using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mission : MonoBehaviour
{
    public GameObject missao;
    // Start is called before the first frame update
    void Start()
    {
        missao.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.GetInt("Missao") == 2)
        {
            missao.SetActive(true);

        }
    }
}
