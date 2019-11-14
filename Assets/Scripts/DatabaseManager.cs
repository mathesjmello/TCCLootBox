using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;

public class DatabaseManager : MonoBehaviour
{
    private string databaseString;
    // Start is called before the first frame update
    void Start()
    {
        databaseString = "URI=file:" + Application.dataPath + "/DB/database.sqlite";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
