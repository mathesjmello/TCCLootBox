using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeScene : MonoBehaviour
{

    public string NextCenaName;
    public string NovoJogo;
    public float timeStart;
    public bool time = false;
    // Start is called before the first frame update
    void Start()
    {

    }

// Update is called once per frame
void Update()
    {
        if (time == true)
        {
            timeStart += Time.deltaTime;
        }
    }
    void OnTriggerEnter2D(Collider2D theCollision) // C#, type first, name in second
    {
        if (theCollision.gameObject.tag == "Player")
        {
            NextScene();
        }
    }

    public void NextScene()
    {
        PlayerPrefs.SetString("_sceneName", NextCenaName);
        LoadingSisten.LoadLevel(NextCenaName);
    }
    public void IntroNextScene()
    {
        if (timeStart <= 26)
        {
        PlayerPrefs.SetString("_sceneName", NextCenaName);
        LoadingSisten.LoadLevel(NextCenaName);
        }
    }

    public void NewGame()
    {
        PlayerPrefs.SetInt("Int", 0);
        Persistence.ResetGame();
        PlayerPrefs.SetString("_sceneName", NovoJogo);
        LoadingSisten.LoadLevel(NextCenaName);
    }
    

    public void QuitGame()
    {
        Application.Quit();
    }

}
