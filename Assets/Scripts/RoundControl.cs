using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Schema;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.UI;

public class RoundControl : MonoBehaviour
{
    public int NumberEnimigs;
    public BasicMeleeEnimy Enimy;
    public List<GameObject> CharList;
    public Button ActionButton;


    // Start is called before the first frame update
    void Start()
    {
        
        CharList = new List<GameObject>();
        for (int i = 0; i < NumberEnimigs; i++)
        {
            var currentEnimy = Enimy.Create(new Vector3(7, Random.Range(-2, 2)), Quaternion.identity);
            CharList.Add(currentEnimy);
        }
        var player = FindObjectOfType<Player>().gameObject; // Mudei por causa da outra cena '<Player>()''
        CharList.Add(player);
        CharList.Sort((a, b) => -1* a.GetComponent<IPreparable>().Iniciativa.CompareTo(b.GetComponent<IPreparable>().Iniciativa));  
        
        ActionButton.onClick.AddListener(StartTurn);
    }

    private void StartTurn()
    {
        if (CharList[0].GetComponent<BasicMeleeEnimy>())
        {
            CharList[0].GetComponent<BasicMeleeEnimy>().Move();
        }
        else
        {
            Debug.Log("vez do player");
        }
        var playedAgent = CharList[0];
        CharList.RemoveAt(0);
        CharList.Add(playedAgent);
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}

