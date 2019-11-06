using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempPlayerHp : MonoBehaviour
{

    public GameObject coll01;
    public GameObject coll02;
    public GameObject coll03;
    public GameObject coll04;
    public int PlayerHealth;

    // Start is called before the first frame update
    void Start()
    {
        PlayerHealth = 2;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col == coll01 || col == coll02 || col == coll03 || col == coll04)
        {
            PlayerHealth--;
            if (PlayerHealth <= 0)
            {
                Destroy(this);
            }
        }
    }
}
