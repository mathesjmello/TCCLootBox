using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace.Battle
{
    public class LootBox: MonoBehaviour
    {
        private TaticsMove player;      
        public GameObject PainelLootBox;
        public GameObject PrefabLoots;       
        void Start()
        {
            PainelLootBox = FindObjectOfType<LootBoxPainel>().gameObject;
            transform.GetComponent<Button>().onClick.AddListener(RunLoot);
            GetActualPlayer();
        }

        private void RunLoot()
        {
            var index = Random.Range(1, 2);
            var loot = Instantiate(PrefabLoots,Vector3.zero,Quaternion.identity,PainelLootBox.transform);
            loot.GetComponent<Loot>().TipeLoot = index;
            Destroy(transform.gameObject);
        }


        public void GetActualPlayer()
        {
            player = RoundManager.turnTeam.Peek();
        }
    }
}