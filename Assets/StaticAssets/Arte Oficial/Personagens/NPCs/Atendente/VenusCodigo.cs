using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VenusCodigo : MonoBehaviour
{
    Animator animator;

    public float timeStart;
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
        timeStart += Time.deltaTime;
        if (timeStart >= 6)
        {
            animator.Play("VenusPiscar");
            timeStart = 0;
        }
    }
    void OnTriggerEnter2D(Collider2D theCollision) // C#, type first, name in second
    {
        if (theCollision.gameObject.tag == "Player")
        {
            animator.Play("VenusCoracao");
        }
    }
}
