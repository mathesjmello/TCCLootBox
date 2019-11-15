using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadQuests : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
     	TextAsset questdata = Resources.Load<TextAsset>("../DB/csv/quests");

     	string[] data = questdata.text.Split(new char[] { '\n' });

     	for (int i = 1; i < data.Length -1; i++){
     		
     		string[] row = data[i].Split(new char[] { ',' });
     		
     		Quest q = new Quest();
     		
     		q.id = row[0];
     		int.TryParse(row[0] out q.id);
     		q.name = row[1];
     		q.npc = row[2];
     		q.desc = row[3];

     		int.TryParse(row[4] out q.status);
     		q.rewards = row[5];
     		q.task = row[6];
     		int.TryParse(row[7], out q.parent);

     	}
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
