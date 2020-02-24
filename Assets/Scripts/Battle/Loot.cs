using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace.Battle
{
    public class Loot: MonoBehaviour
    {
        public int BadDrop = 50, MidDrop= 75, GoodDrop =90;
        public int TypeLoot;
        public bool Select;
        private TaticsMove player;
        public int _rarit;
        public Button botao;
        public Image m_Image;

        public Sprite Run_Sprite;

        public Sprite Fight_Sprite;

        public Transform text;



        //private Animator PlayerAnim;



        private void Start()
        {
            //PlayerAnim = gameObject.GetComponent<Animator>();

            text = transform.GetChild(0);

            m_Image = GetComponent<Image>();
            botao = transform.GetComponent<Button>();
            botao.onClick.AddListener(SpendLoot);
            botao.onClick.AddListener(Clicked);
            int prob = Random.Range(0, 100);
            SelectRarit(prob);
            player = RoundManager.turnTeam.Peek();
            
            if (TypeLoot == 1)
            {
                m_Image.sprite = Run_Sprite;
            }
            else
            {

                m_Image.sprite = Fight_Sprite;
            }
            text.GetComponent<Text>().text = _rarit.ToString();
        }

        private void Clicked()
        {
            Select = true;
        }

        public void SpendLoot()
        {
            Select = false;
            player.LootGenTest = TypeLoot;
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