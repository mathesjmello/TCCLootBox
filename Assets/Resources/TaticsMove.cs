using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaticsMove : MonoBehaviour
{
    List<TileScript> selectableTiles = new List<TileScript>();
    
    public int move = 3;
    public float jumpHeight = 2;

    Vector3 velocity = new Vector3();
    Vector3 pointVector = new Vector3();

    protected void Init()
    {

    }
}
