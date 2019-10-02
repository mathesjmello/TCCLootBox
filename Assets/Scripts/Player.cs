using UnityEngine;

namespace DefaultNamespace
{
    public class Player: MonoBehaviour, IDamegeable, IFightable
    {
        private int _life;
        private int _force;

        public int Hp
        {
            get
            {
                return _life;
            }
            set
            {
                _life = value;
                if (_life<=0)
                {
                    Die();
                }
            }
        }
        public int HitForce { get { return _force; } set { _force = value; } }

        private void Die()
        {
            Destroy(gameObject);
        }

        public void Damege(int damege)
        {
            _life =- damege;
        }

        
        public void Attack()
        {
            throw new System.NotImplementedException();
        }
    }
}