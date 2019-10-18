using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DefaultNamespace;

public class RoundTacticController : MonoBehaviour
{
    
    public int NumberEnimigs;
    public BasicMeleeEnimy Enemy;
    public List<GameObject> CharList;
    public Button ActionButton;


    // Start is called before the first frame update
    void Start()
    {
        
        CharList = new List<GameObject>();
        for (int i = 0; i < NumberEnimigs; i++)
        {
            var currentEnemy = Enemy.Create(new Vector3(7, Random.Range(-2, 2)), Quaternion.identity);
            CharList.Add(currentEnemy);
        }
        var player = FindObjectOfType<PlayerMove>().gameObject; // Mudei por causa da outra cena '<Player>()''
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
