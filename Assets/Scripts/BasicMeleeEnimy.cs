using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DefaultNamespace
{
    public class BasicMeleeEnimy: MonoBehaviour, IMovable, IInstansable, IDamegeable, IFightable

    {
        public int MoveRange=1;
        private int _life;
        private int _force;
        private Player[] _poolofTarguets;
        private GameObject _closerTarguet;

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
            transform.position = (_closerTarguet.transform.position - transform.position).normalized * MoveRange;
        }

        public void SetTarguet()
        {
            _poolofTarguets = FindObjectsOfType<Player>();
            foreach (var t in _poolofTarguets)
            {
                if ((Vector3.Distance(_closerTarguet.transform.position, transform.position)>=(Vector3.Distance(t.gameObject.transform.position, transform.position))))
                {
                    _closerTarguet = t.gameObject;
                }
            }

      
        }

        public IInstansable Create(Vector3 position, Quaternion rotation)
        {
            return Instantiate(this, position, rotation);
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