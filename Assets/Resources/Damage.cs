using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{

    public GameObject Selection;
    private GameObject player;
    PlayerMove playerMove;

    private float distX;
    private float distZ;
    private float PEdist;
    private float distTotal;
    private float PositivizadorX;
    private float PositivizadorZ;
    private float DX;
    private float DZ;

    bool selectable = false;
    bool selected = false;

    int tempLife;

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
        if (playerMove.LootGenTest == 2)
        {
            selectable = true;
        }
        else
        {
            selectable = false;
        }
        if (tempLife == 0)
        {
            Debug.Log("Morreu");
        }
        Attack();
        DistCheck();
    }

    void Attack()
    {
        if (selected == true && distTotal < 6)
        {
            if (Input.GetMouseButtonDown(0))
            {
                tempLife -= 20;
            }
        }
    }

    void DistCheck()
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
        Debug.Log(distTotal);
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
