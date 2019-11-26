using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Persistence
{
    private static float _masterV = 1;
    private static float _musicV = 1;
    private static float _sfxV = 1;
    private static float _dialogV = 1;
    private static float _indexSpam = 0;
    private static string _sceneName = "Prolog";


    public static void SaveData()
    {
        PlayerPrefs.SetFloat("MasterV", _masterV);
        PlayerPrefs.SetFloat("MusicV", _musicV);
        PlayerPrefs.SetFloat("SfxV", _sfxV);
        PlayerPrefs.SetFloat("DialogV", _dialogV);
    }

    public static void LoadData()
    {
        _masterV = PlayerPrefs.GetFloat("MasterV");
        _musicV = PlayerPrefs.GetFloat("MusicV");
        _sfxV = PlayerPrefs.GetFloat("SfxV");
        _dialogV = PlayerPrefs.GetFloat("DialogV");
    }

    public static void ResetGame()
    {
        PlayerPrefs.SetString("_sceneName",_sceneName);
        PlayerPrefs.SetInt("indexSpam",0);
        PlayerPrefs.SetInt("Monstro1", 0);
        PlayerPrefs.SetInt("Monstro2", 0);
        PlayerPrefs.SetInt("Monstro3", 0);
        PlayerPrefs.SetInt("Missao", 0);
    }
    
}
