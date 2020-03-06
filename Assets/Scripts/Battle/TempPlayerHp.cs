using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TempPlayerHp : MonoBehaviour
{
    public string NextCenaName;

    public GameObject coll01;
    public GameObject coll02;
    public GameObject coll03;
    public GameObject coll04;
    public int PlayerHealth;
    public Image LifeBar;
    public float tempLife;
    float waitForSec = 5.0f;
    
    public Animator slimeAnimator;
     
    // void Awake () {
    //  slimeAnimator = slimeObject.GetComponent<Animator> ();
    // }

    // Start is called before the first frame update
    void Start()
    {
        PlayerHealth = 100;
    }

    // Checar a vida do player a cada Frame
    void Update()
    {
        // LifeCheck();
        // Debug.Log("P. Health: " + PlayerHealth);              
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col == coll01 || col == coll02 || col == coll03 || col == coll04)
        {
            Debug.Log("Collision");



            if (PlayerHealth <= 0)
            {
                PlayerPrefs.SetString("_sceneName", NextCenaName);
                LoadingSisten.LoadLevel(NextCenaName);
            }
        }
    }

    public void LifeCheck()
    {
        
        if( slimeAnimator.GetCurrentAnimatorStateInfo(0).IsName("GS_Attack"))
         {
                PlayerHealth--;    
                LifeBar.fillAmount -= 1.0f / waitForSec * Time.deltaTime;
         }
        
    }
}
