using System.Runtime.InteropServices.ComTypes;
using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace.Battle
{
    public class LootBox: MonoBehaviour
    {
        private TaticsMove player;
        
        void Start()
        {
            transform.GetComponent<Button>().onClick.AddListener(RunLoot);
            GetActualPlayer();
        }

        private void RunLoot()
        {
            player.BeginTurn();
        }

        public void GetActualPlayer()
        {
            player = RoundManager.turnTeam.Peek();
        }
    }
}