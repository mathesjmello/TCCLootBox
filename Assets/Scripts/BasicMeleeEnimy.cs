using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DefaultNamespace
{
    public class BasicMeleeEnimy: MonoBehaviour, IMovable, IInstansable, IDamegeable, IFightable, IPreparable

    {
        public int MoveRange=1;
        private int _life;
        private int _force;
        public Player[] _poolofTarguets;
        public GameObject _closerTarguet;
        
        public int Iniciativa { get; set; }
        
        
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

        public int HitForce 
        {   
            get{ return _force;}
            set { _force = value; }
        }

        private void Awake()
        {
            Iniciativa = Random.Range(0, 20);
            SetTarguet();
        }

        private void Die()
        {
            throw new System.NotImplementedException();
        }

        
        public virtual void Move()
        {
            if ((Vector3.Distance(_closerTarguet.transform.position, transform.position)<=1))
            {
                Attack();
                return;
            }
            transform.position = (_closerTarguet.transform.position - transform.position).normalized;
        }

        public void SetTarguet()
        {
            _poolofTarguets = FindObjectsOfType<Player>();
            _closerTarguet = _poolofTarguets[0].gameObject;
            foreach (var t in _poolofTarguets)
            {
                if ((Vector3.Distance(_closerTarguet.transform.position, transform.position)<=(Vector3.Distance(t.gameObject.transform.position, transform.position))))
                {
                    _closerTarguet = t.gameObject;
                }
            }

      
        }

        public GameObject Create(Vector3 position, Quaternion rotation)
        {
            return Instantiate(this, position, rotation).gameObject;
        }

        
        public void Damege(int damege)
        {
            _life =- damege;
        }

        
        public void Attack()
        {
            _closerTarguet.GetComponent<Player>().Damege(_force);
        }

        
    }
}