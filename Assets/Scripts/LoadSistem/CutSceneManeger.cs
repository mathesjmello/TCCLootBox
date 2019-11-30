using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Video;

public class CutSceneManeger : MonoBehaviour
{
    public VideoPlayer VideoClip;
    public string NextCenaName;
    public string NovoJogo;
    
    // Start is called before the first frame update
    void Start()
    {
        VideoClip.loopPointReached += EndReached;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NextScene()
    {
        PlayerPrefs.SetString("_sceneName", NextCenaName);
        LoadingSisten.LoadLevel(NextCenaName);
    }
    void EndReached(UnityEngine.Video.VideoPlayer vp)
    {
        PlayerPrefs.SetString("_sceneName", NextCenaName);
        LoadingSisten.LoadLevel(NextCenaName);
    }
    

    public void NewGame()
    {
        Persistence.ResetGame();
        PlayerPrefs.SetString("_sceneName", NovoJogo);
        LoadingSisten.LoadLevel(NextCenaName);
    }
   
    public void QuitGame()
    {
        Application.Quit();
    }

}
