using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DefaultNamespace;
using UnityEngine;

public class RoundControl : MonoBehaviour
{
    public int NumberCharacters;
    public GameObject Chara;
    private List<GameObject> _charList;

    private List<int> _iniciativaList;
    // Start is called before the first frame update
    void Start()
    {
        _charList = new List<GameObject>();
        _iniciativaList = new List<int>();
        for (int i = 0; i < NumberCharacters; i++)
        {
            var currentChar = Instantiate(Chara);
            var rand = Random.Range(0, 20);
            _iniciativaList.Add(rand );
            _charList.Add(currentChar);
        }
        
        _iniciativaList.Sort((a, b) => -1* a.CompareTo(b));
        
        
    }

    

    // Update is called once per frame
    void Update()
    {
        
    }
}

