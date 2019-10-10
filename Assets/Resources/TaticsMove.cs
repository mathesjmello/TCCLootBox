using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaticsMove : MonoBehaviour
{
    List<TileScript> selectableTiles = new List<TileScript>();
    GameObject[] tiles;

    Stack<TileScript> path = new Stack<TileScript>();
    TileScript currentTile;

    public int move = 3;
    public float jumpHeight = 2;
    public float moveSpeed = 2;

    Vector3 velocity = new Vector3();
    Vector3 pointVector = new Vector3();

    float halfHeight = 0;

    protected void Init()
    {
    	tiles = GameObject.FindGameObjectsWithTag("Tile");

    	halfHeight = 
    }
}
