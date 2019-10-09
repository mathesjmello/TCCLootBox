using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    public GameObject MenuPainel, OptionsPainel, SoundPainel;

    public Button SoundButton, OptionsButton;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        SoundButton.onClick.AddListener(OpenSound);
        OptionsButton.onClick.AddListener(OpenOptions);
    }

    private void OpenOptions()
    {
        OptionsPainel.SetActive(true);
        MenuPainel.SetActive(false);
    }

    private void OpenSound()
    {
        SoundPainel.SetActive(true);
        MenuPainel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            MenuPainel.SetActive(!MenuPainel.activeSelf);
        }
    }
}
