using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CafeteriaCodigo : MonoBehaviour
{
    // Start is called before the first frame update
    Animator animator;

    public float timeStart1;
    public float timeStart2;

    // Start is called before the first frame update
    private void Awake()
    {
        //cache the animator component
        animator = GetComponent<Animator>();
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timeStart1 += Time.deltaTime;
        timeStart2 += Time.deltaTime;

        if (timeStart1 >= 7)
        {
            animator.Play("CafeteriaPiscar");
            timeStart1 = 0;
        }
        if (timeStart2 >= 10)
        {
            animator.Play("CafeteriaCabelo");
            timeStart2 = 0;
        }
    }
}