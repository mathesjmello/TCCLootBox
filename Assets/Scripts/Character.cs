using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DefaultNamespace
{
    public class Character: MonoBehaviour
    {
        public int Iniciativa;

        void Start()
        {
            Iniciativa = Random.Range(0, 20);
        }
    }
}