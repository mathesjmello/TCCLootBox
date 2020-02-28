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
    public int TypesOfloot = 2;
    public List<Loot> LLoot;
    

    private void ChoseOne()
    {
        return;
    }

    public void CheckChange(GameObject o)
    {
        var chosedLoot = o.GetComponent<Loot>();
        if (chosedLoot._rarit>1)
        {
            for (int i = 0; i < TypesOfloot; i++)
            {
                var loot = Instantiate(PrefabLoots, Vector3.zero, Quaternion.identity, NewLootPainel.transform).GetComponent<Loot>();
                loot.TypeLoot = i;
                LLoot.Add(loot);
            }

            foreach (var l in LLoot)
            {
                l._rarit = chosedLoot._rarit - 1;
                l.CanUse = false;
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
