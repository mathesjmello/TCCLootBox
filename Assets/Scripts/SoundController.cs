using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SoundController : MonoBehaviour
{
    public AudioMixer MasterMixer;

    public Slider MasterSlider;
    public Slider MusicSlider;
    public Slider SfxSlider;
    public Slider DialogSlider;
    

    float dialogVolume;
    float masterVolume;
    float musicVolume;
    float sfxVolume;
    // Start is called before the first frame update

    private void Awake()
    {
        MasterSlider.maxValue = 1;
        MasterSlider.minValue = -60;
        MusicSlider.maxValue = 1;
        MusicSlider.minValue = -80;
        SfxSlider.maxValue = 1;
        SfxSlider.minValue = -60;
        DialogSlider.maxValue = 1;
        DialogSlider.minValue = -60;
        
        masterVolume = PlayerPrefs.GetFloat("MasterV");
        musicVolume = PlayerPrefs.GetFloat("MusicV");
        sfxVolume = PlayerPrefs.GetFloat("SfxV");
        dialogVolume = PlayerPrefs.GetFloat("DialogV");

        MasterSlider.value = masterVolume;
        MusicSlider.value = musicVolume;
        SfxSlider.value = sfxVolume;
        DialogSlider.value = dialogVolume;
    }

    public void UpdateMasterVolume()
    {
        masterVolume = MasterSlider.value;
    }
    public void UpdateMusicVolume()
    {
        musicVolume = MusicSlider.value;
    }
    public void UpdateSfxVolume()
    {
        sfxVolume = SfxSlider.value;
    }
    public void UpdateDialogVolume()
    {
        dialogVolume = DialogSlider.value;
    }
    
    
    void Update()
    {
        MasterMixer.SetFloat("MasterV", masterVolume);

        MasterMixer.SetFloat("MusicaV", musicVolume);
        
        MasterMixer.SetFloat("SfxV", sfxVolume);

        MasterMixer.SetFloat("DialogV", dialogVolume);
    }

    public void ConfirmChanges()
    
    {   PlayerPrefs.SetFloat("MasterV", masterVolume);
        PlayerPrefs.SetFloat("MusicV", musicVolume);
        PlayerPrefs.SetFloat("SfxV", sfxVolume);
        PlayerPrefs.SetFloat("DialogV", dialogVolume);
    }

    public void Undo()
    {
        masterVolume = PlayerPrefs.GetFloat("MasterV");
        musicVolume = PlayerPrefs.GetFloat("MusicV");
        sfxVolume = PlayerPrefs.GetFloat("SfxV");
        dialogVolume = PlayerPrefs.GetFloat("DialogV");
    }
}
