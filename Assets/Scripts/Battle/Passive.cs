using System.Collections;
using System.Collections.Generic;
using System.Xml;
using DefaultNamespace.Battle;
using UnityEngine;

public class Passive : MonoBehaviour
{
    
    public GameObject PrefabLoots;
    public GameObject ChoseTransfom;
    public GameObject NewLootPainel;
    public GameObject Lootpainel;
    public int TypesOfloot = 2;
    public List<Loot> LLoot;
    private Loot chosedLoot;
    

    private void ChoseOne()
    {
        return;
    }

    public void CheckChange(GameObject o)
    {
        chosedLoot = o.GetComponent<Loot>();
        if (chosedLoot._rarit>1)
        {
            for (int i = 0; i < TypesOfloot; i++)
            {
                var loot = Instantiate(PrefabLoots, Vector3.zero, Quaternion.identity, NewLootPainel.transform).GetComponent<Loot>();
                loot.TypeLoot = i;
                loot.SetValue(false, chosedLoot._rarit - 1, i);
                LLoot.Add(loot);
            }
        }

    }



    public void CleanPainel()
    {
        int children = NewLootPainel.transform.childCount;
        for (int i = 0; i < children; ++i)
            Destroy(NewLootPainel.transform.GetChild(i).gameObject);
    }
}
