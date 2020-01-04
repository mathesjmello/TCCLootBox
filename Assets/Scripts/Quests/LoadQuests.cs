using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadQuests : MonoBehaviour
{
    List<Quest> quests = new List<Quest>();

    void Start()
    {
     	TextAsset questdata = Resources.Load<TextAsset>("../DB/csv/quests");

     	string[] data = questdata.text.Split(new char[] { '\n' });

     	for (int i = 1; i < data.Length -1; i++){
     		
     		string[] row = data[i].Split(new char[] { ',' });
     		
     		if (row[1] != "")
     		{
     			Quest q = new Quest();
     		
	     		
	     		int.TryParse(row[0], out q.id);
	     		q.name = row[1];
	     		q.npc = row[2];
	     		q.desc = row[3];

	     		int.TryParse(row[4], out q.status);
	     		q.rewards = row[5];
	     		q.task = row[6];
	     		int.TryParse(row[7], out q.parent);

	     		quests.Add(q);
     		}
     	}

     	foreach (Quest q in quests) {
     		Debug.Log(q.name);
     	}
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // public void GetQuestInfo(List<Quest> q) {
    // // 	foreach (Quest q in quests) {
    // //  		// Debug.Log(q.name);
    // //  	}
    // // }
    // }
}
