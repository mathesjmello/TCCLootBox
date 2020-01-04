using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TacticsCamera : MonoBehaviour
{
    // Start is called before the first frame update
    public void RotateLeft()
    {
     	transform.Rotate(Vector3.up, 90, Space.Self);   
    }

    // Update is called once per frame
    public void RotateRight()
    {
      transform.Rotate(Vector3.up, -90, Space.Self);   
    }
}
