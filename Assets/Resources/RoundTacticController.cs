using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundTacticController : MonoBehaviour
{
    public int NumberEnimigs;
    public BasicMeleeEnemy Enemy;
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
        if (CharList[0].GetComponent<BasicMeleeEnemy>())
        {
            CharList[0].GetComponent<BasicMeleeEnemy>().Move();
        }
        else
        {
            Move();
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
