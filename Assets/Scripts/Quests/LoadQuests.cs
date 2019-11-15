using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadQuests : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
     	TextAsset questdata = Resources.Load<TextAsset>("../DB/csv/quests");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
