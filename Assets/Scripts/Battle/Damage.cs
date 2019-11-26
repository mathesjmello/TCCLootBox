using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Damage : MonoBehaviour
{

    public GameObject Selection;
    private GameObject player;
    public Image LifeBar;
    PlayerMove playerMove;
    public Animator PlayerAnim;

    private float distX;
    private float distZ;
    private float PEdist;
    private float distTotal;
    private float PositivizadorX;
    private float PositivizadorZ;
    private float DX;
    private float DZ;

    public GameObject coll01;
    public GameObject coll02;
    public GameObject coll03;
    public GameObject coll04;

    bool selectable = false;
    public bool selected = false;

    float tempLife;

    private void Awake()
    {
        
        player = GameObject.Find("Player");
        playerMove = player.GetComponent<PlayerMove>();
    }
    // Start is called before the first frame update
    void Start()
    {
        tempLife = 100;
    }

    // Update is called once per frame
    void Update()
    {
        Attack();
    }

    void Attack()
    {
        if (playerMove.LootGenTest == 2 && distTotal < 6)
        {
            selectable = true;
            if (Input.GetMouseButtonDown(0)&& Selection.activeSelf)
            {
                PlayerAnim.SetTrigger("Attack");
                tempLife -= playerMove.HitForce*10;
                float barra = tempLife / 100;
                Debug.Log(barra);
                LifeBar.fillAmount = barra;
                if (tempLife <= 0)
                {
                    Destroy(gameObject);
                }
                playerMove.LootGenTest = 0;
                RoundManager.EndTurn();
            }
        }
    }

    public void DistCheck()
    {
        distX = (player.transform.position.x - transform.position.x)/1;
        distZ = (player.transform.position.z - transform.position.z)/1;

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

    private void OnMouseEnter()
    {
        if (selectable == true)
        {
            Selection.SetActive(true);
            selected = true;
        }
    }

    private void OnMouseExit()
    {
        Selection.SetActive(false);
        selected = false;
    }

}
