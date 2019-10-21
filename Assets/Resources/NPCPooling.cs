using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCPooling : MonoBehaviour
{
    [System.Serializable]
    public class Pool 
    {
    	public string tag;
    	public GameObject prefab;
    	public int size;
    }

    public Dictionary<string, Queue<GameObject>> poolDictionary;
    public List<Pool> pools;

    void Start()
    {
				poolDictionary = new Dictionary<string, Queue<GameObject>>();

				foreach (Pool pool in pools)
				{
					Queue<GameObject> objectPool = new Queue<GameObject>();

					for (int i = 0; i < pool.size; i++)
					{
						
					}
				}
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
