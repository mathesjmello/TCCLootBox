using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GerenciadorDeSpawn : MonoBehaviour
{
    public GameObject [] Locais;

    public GameObject Player;

    private int _indexSpam;
    // Start is called before the first frame update
    void Start()
    {
        _indexSpam = PlayerPrefs.GetInt("indexSpam");
        Player.transform.position = Locais[_indexSpam].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
