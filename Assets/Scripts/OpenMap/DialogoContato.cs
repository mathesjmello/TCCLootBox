using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogoContato : MonoBehaviour
{
    public GameObject panelBox;
    public GameObject Interrogaçao;
    public GameObject Conversa;
    public bool podeFalar = false;
    [SerializeField]
    private int linhaAtual;
    public TextMeshProUGUI textoMensagem;
    public string[] texto;
    public int limitText;

    //public float timer = 0;
    public static bool estaFalando = false;
    [SerializeField]
    private bool teste = false;
    [SerializeField]
    private bool jaComecaFalando;
    [SerializeField]
    // private bool[] Mike = 
    public GameObject img;
    public GameObject[] imgs;
    
    //[SerializeField]
    //private bool[] ray;
    public bool rodaCut = false;
    void Start()
    {
        textoMensagem.text = texto[linhaAtual].ToString();
        img = imgs[linhaAtual];
        

    }

    // Update is called once per frame
    void Update()
    {

        if (podeFalar)
        {
            if (linhaAtual >= limitText)
            {
                Desabilitar();
                podeFalar = false;
                linhaAtual = 0;

            }
            //img.SetActive(false);
            //img = imgs[linhaAtual];
            estaFalando = true;


            img.SetActive(false);
            img = imgs[linhaAtual];
            if (img == imgs[linhaAtual])
            {
                img.SetActive(true);
            }


            if (Input.GetKeyDown(KeyCode.E))
            {
                //img.SetActive(false);
                
                linhaAtual++;
                textoMensagem.text = texto[linhaAtual].ToString();
                // img.SetActive(true);

            }

        }
        teste = estaFalando;

    }


    public void OnTriggerStay2D(Collider2D collision)
    {



        if (collision.gameObject.CompareTag("Player"))
        {
            if (jaComecaFalando)
            {
                Time.timeScale = 0f;

                podeFalar = true;
                Habilitar();
            }
            else if (!jaComecaFalando)
            {
                Time.timeScale = 0f;

                podeFalar = true;
                Habilitar();

            }
        }

    }

    void Habilitar()
    {
        panelBox.SetActive(true);

        //estaFalando = true;
        img.SetActive(true);
    }
    void Desabilitar()
    {
        panelBox.SetActive(false);
        estaFalando = false;
        Interrogaçao.SetActive(false);
        Conversa.SetActive(false);


    }

}

