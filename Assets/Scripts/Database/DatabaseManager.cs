using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using Mono.Data.Sqlite; // Get error reference for SQLite Submodule

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
