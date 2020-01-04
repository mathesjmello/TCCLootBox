using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingSisten : MonoBehaviour
{
    static AsyncOperation operaçao;
    public bool Anima;
    public Slider barraDeLoading;

    // Use this for initialization
    void Start () {

        StartCoroutine(nameof(LevelLoad));
        
    }


    void Update()
    {
       barraDeLoading.value = 1 - Mathf.Clamp01(operaçao.progress/.9f);
        print(operaçao.progress);


    }


    IEnumerator LevelLoad()
    {
        
            operaçao = SceneManager.LoadSceneAsync(PlayerPrefs.GetString("_sceneName"));
            operaçao.allowSceneActivation = false;

            while (!operaçao.isDone)
            {
            
                if (operaçao.progress <= 0.9f)
                {
                    // barraDeLoading.value = 0;
                    if (Anima)
                    {
                        operaçao.allowSceneActivation = true;
                    }

                    yield return null;
                }
            
                yield return null;
            }
        
    }

    public static void LoadLevel(string sceneIndex)
    {
        operaçao = SceneManager.LoadSceneAsync(sceneIndex);
        



    }

    IEnumerator LoadAsynchronously(int sceneIndex)
    {
        operaçao = SceneManager.LoadSceneAsync(sceneIndex);

        while (!operaçao.isDone)
        {
            print(operaçao.progress);
            yield return null;

        }
    }

    public void AnimaEvent()
    {
        Anima = true;
    }
}
