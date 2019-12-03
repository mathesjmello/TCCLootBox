using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TempDistCheck : MonoBehaviour
{
    public string NextCenaName;


    public GameObject coll01;
    public GameObject coll02;
    public GameObject coll03;
    public GameObject coll04;

    private GameObject player;

    private float distX;
    private float distZ;
    public float distTotal;
    private float PositivizadorX;
    private float PositivizadorZ;
    private float DX;
    private float DZ;

    public float hitTime;

    public bool canHit;
    public int hitCount;

    public Button SkipButton;

    public Animator GS;
    public Animator PlayerAnim;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        canHit = true;
        hitCount = 0;
        SkipButton.onClick.AddListener(SkipTurn);
    }

    // Update is called once per frame
    void Update()
    {
        DistCheck();
        if (distTotal <= 1.5f && canHit == true)
        {
            TestDamage();
            //GS.ResetTrigger("Attack");
        }

        /*if (Input.GetMouseButtonDown(0))
        {
            canHit = true;
        }*/
        if (Input.GetMouseButtonDown(1))
        {
            hitCount = 0;
        }

        //hitTime = Time.DeltaTime;

            /*if (distTotal <= 1)
            {
                if(hitTime >= 2)
                {
                    coll01.SetActive(true);
                    coll02.SetActive(true);
                    coll03.SetActive(true);
                    coll04.SetActive(true);
                }
            }
            else
            {
                coll01.SetActive(false);
                coll02.SetActive(false);
                coll03.SetActive(false);
                coll04.SetActive(false);
            }

            if (Input.GetMouseButtonDown(0))
            {
                coll01.SetActive(false);
                coll02.SetActive(false);
                coll03.SetActive(false);
                coll04.SetActive(false);
                hitTime = 0;
            }*/
    }

    private void SkipTurn()
    {
        canHit = true;

    }

    private void TestDamage()
    {
        GS.SetTrigger("Attack");
        PlayerAnim.SetTrigger("Damage");
        hitCount++;
        canHit = false;
        if (hitCount == 5)
        {
            StartCoroutine("DeathAnim");
        }
    }

    IEnumerator DeathAnim()
    {
        PlayerAnim.SetBool("Morto", true);
        yield return new WaitForSeconds(2.0f);
        PlayerPrefs.SetString("_sceneName", NextCenaName);
        LoadingSisten.LoadLevel(NextCenaName);
    }

    public void DistCheck()
    {
        distX = (player.transform.position.x - transform.position.x) / 1;
        distZ = (player.transform.position.z - transform.position.z) / 1;

        if (distX < 0)
        {
            PositivizadorX = -1f;
        }
        else
        {
            PositivizadorX = 1f;
        }

        if (distZ < 0)
        {
            PositivizadorZ = -1f;
        }
        else
        {
            PositivizadorZ = 1f;
        }
        DX = distX * PositivizadorX;
        DZ = distZ * PositivizadorZ;
        distTotal = DX + DZ;
    }

}
