using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamerasControl : MonoBehaviour
{
    public GameObject CameraCidade;
    public GameObject CameraJogador ;
    
    // Start is called before the first frame update
    void Start()
    {

    }
    public virtual void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            CameraCidade.SetActive(true);
           // CameraJogador.SetActive(false);
        }

    }
    public virtual void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            //CameraJogador.SetActive(true);
            CameraCidade.SetActive(false);
            
        }

    }

    // Update is called once per frame
    void Update()
    {

    }
}