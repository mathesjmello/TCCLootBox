using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<Item> itemList = new List<Item>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // [TESTE] - Adicionar Item no Inventário
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            InventoryManager.instance.AddItem(itemList[Random.Range(0, itemList.Count)]);
        }
    }
}
