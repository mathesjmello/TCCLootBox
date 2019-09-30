using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorControl : MonoBehaviour
{
    public GameObject NextDoor;

    private Transform _spawnTransform;

    private GameObject _player;
    // Start is called before the first frame update
    void Start()
    {
        _player = FindObjectOfType<PlayerController>().gameObject;
        _spawnTransform = NextDoor.transform.GetChild(0);
    }


    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            _player.transform.position = _spawnTransform.position;
            _player.transform.rotation = _spawnTransform.rotation;
            _player.transform.rotation = _spawnTransform.rotation;
        }
    }
}
