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

    // Start is called before the first frame update
    
    public void UpdateMasterVolume()
    {
        MasterMixer.SetFloat("MasterV", MasterSlider.value * 20);
    }
    public void UpdateMusicVolume(float sliderValue)
    {
        MasterMixer.SetFloat("MusicaV", MusicSlider.value * 20);
    }
    public void UpdateSfxVolume(float sliderValue)
    {
        MasterMixer.SetFloat("SfxV", SfxSlider.value * 20);
    }
    public void UpdateDialogVolume(float sliderValue)
    {
        MasterMixer.SetFloat("DialogV", DialogSlider.value * 20);
    }
}
