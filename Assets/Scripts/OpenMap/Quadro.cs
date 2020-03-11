using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quadro : MonoBehaviour
{
    public GameObject Abrir;

    void Start()
    {
        PlayerPrefs.SetInt("DialogoGuilda", 2);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerStay2D(Collider2D collision)
    {



        if (collision.gameObject.CompareTag("Player"))
        {
            
            if (Input.GetKeyUp(KeyCode.E) && PlayerPrefs.GetInt("DialogoGuilda", 0) >= 1)
            {
                Abrir.SetActive(true);

                if (PlayerPrefs.GetInt("DialogoGuilda", 0) == 1)
                {
                    PlayerPrefs.SetInt("DialogoGuilda", 2);
                }

            }
        }

    }
}
