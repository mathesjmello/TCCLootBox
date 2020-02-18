using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Armeira : MonoBehaviour
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
        if(timeStart >= 8)
        {
            animator.Play("ArmeiraAnimationPiscando");
            timeStart = 0;
        }
    }
    void OnTriggerEnter2D(Collider2D theCollision) // C#, type first, name in second
    {
        if (theCollision.gameObject.tag == "Player")
        {
            animator.Play("ArmeiraAnimationOi");
        }
    }
}
