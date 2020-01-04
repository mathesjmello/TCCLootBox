using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    public GameObject MenuPainel,  SoundPainel, CreditsPainel;
    public static bool Pausa = false;
    public Button SoundButton, OptionsButton, BackButton, CreditButton;
    public bool Menu = false;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        SoundButton.onClick.AddListener(OpenSound);
        BackButton.onClick.AddListener(OpenMenu);
    }

    private void OpenMenu()
    {
        SoundPainel.SetActive(false);
        MenuPainel.SetActive(true);
    }

    

    private void OpenCredits()
    {
        CreditsPainel.SetActive(true);
        MenuPainel.SetActive(false);
        SoundPainel.SetActive(false);
    }

    private void OpenSound()
    {
        SoundPainel.SetActive(true);
        MenuPainel.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    // Update is called once per frame
    void Update()
    {
        if (Menu == false)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {


                if (!CreditsPainel.activeSelf && !SoundPainel.activeSelf)
                {

                    MenuPainel.SetActive(!MenuPainel.activeSelf);
                    if (Time.timeScale == 1.0f)
                        Time.timeScale = 0.0f;
                    else
                        Time.timeScale = 1.0f;
                }

                
            }
        }
    }
}
