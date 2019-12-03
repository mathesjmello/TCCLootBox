using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace.Battle
{
    public class Loot: MonoBehaviour
    {
        public int BadDrop = 50, MidDrop= 75, GoodDrop =90;
        public int TipeLoot;
        private TaticsMove player;
        private int _rarit;

        Image m_Image;
        public Sprite Run_Sprite;
        public Sprite Fight_Sprite;

        //private Animator PlayerAnim;


        private void Start()
        {
            //PlayerAnim = gameObject.GetComponent<Animator>();

            var text = transform.GetChild(0);
            m_Image = GetComponent<Image>();
            var botao = transform.GetComponent<Button>();
            botao.onClick.AddListener(SpendLoot);
            int prob = Random.Range(0, 100);
            SelectRarit(prob);
            player = RoundManager.turnTeam.Peek();
            if (TipeLoot == 1)
            {
                m_Image.sprite = Run_Sprite;
            }
            else
            {

                m_Image.sprite = Fight_Sprite;
            }
            text.GetComponent<Text>().text = _rarit.ToString();
        }

        private void SpendLoot()
        {
            player.LootGenTest = TipeLoot;
            player.move = _rarit;
            player.HitForce = _rarit;
            player.BeginTurn();
            Destroy(gameObject);
        }

        private void SelectRarit(int prob)
        {
            if (prob>GoodDrop)
            {
                _rarit = 4;
                //PlayerAnim.SetTrigger("PositiveReact");
            }
            else if (prob>MidDrop)
            {
                _rarit = 3;
            }
            else if (prob>BadDrop)
            {
                _rarit = 2;
            }
            else if (prob<=BadDrop)
            {
                _rarit = 1;
                //PlayerAnim.SetTrigger("NegativeReact");
            }
        }
    }
}