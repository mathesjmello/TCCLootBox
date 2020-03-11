using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogo : MonoBehaviour
{
    public GameObject panelBox;
    public GameObject Maga;
    public GameObject Interrogaçao;
    public GameObject Conversa;
    public bool podeFalar = false;
    public bool Guilda = false;


    [SerializeField]
    private int linhaAtual;
    public TextMeshProUGUI textoMensagem;
    public string[] texto;
    public int limitText;
    public int NivelEntrando;

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
    private int conta;
    //[SerializeField]
    //private bool[] ray;
    void Start()
    {
        textoMensagem.text = texto[linhaAtual].ToString();
        img = imgs[linhaAtual];
        conta = 0;

    }

    // Update is called once per frame
    void Update()
    {
       
            if (podeFalar)
        {
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
                if (linhaAtual >= limitText)
                {
                    Time.timeScale = 1f;
                    Desabilitar();
                    podeFalar = false;
                    linhaAtual = 0;

                }
                linhaAtual++;
                textoMensagem.text = texto[linhaAtual].ToString();
                // img.SetActive(true);
               
            }
            if (linhaAtual == 40)
            {
                //img.SetActive(false);
                Maga.SetActive(true);

            }
            if (linhaAtual >= 43)
            {
                //img.SetActive(false);
                Maga.SetActive(false);

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
                else if (!jaComecaFalando && Input.GetKeyUp(KeyCode.E))
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
        if (Guilda == true)
        {
            PlayerPrefs.SetInt("DialogoGuilda", NivelEntrando);
        
        }
            Interrogaçao.SetActive(false);
            Conversa.SetActive(false);


    }
    public void ativaSprite()
    {

    }
}
