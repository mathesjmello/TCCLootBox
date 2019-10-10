using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class MenuScript
{
    // Start is called before the first frame update
    [MenuItem("Tools/Assing Tile Material")]
    public static void AssingTileMaterial()
    {
    	GameObject[] tiles = GameObject.FindGameObjectsWithTag("Tile");
    	Material material = Resources.Load<Material>("Tile");

    	foreach (GameObject t in tiles)
    	{
    		t.GetComponent<Renderer>().material = material;
    	}
    }
}
