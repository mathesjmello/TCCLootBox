using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotoesSlime : MonoBehaviour
{
    Animator animator;
    public bool SlimeRoxo = false;
    public bool SlimeVermelho = false;
    public bool SlimeVerde = false;

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
        
    }
    public void Entrar()
    {
        if (SlimeVermelho == true)
        {
            animator.Play("SlimeVermelho");
        }
        if (SlimeRoxo == true)
        {
            animator.Play("SlimeRoxo");
        }
        if (SlimeVerde == true)
        {
            animator.Play("SlimeVerde");
        }
    }
    public void OnTriggerExit()
    {
        animator.Play("Idle");
    }
}
