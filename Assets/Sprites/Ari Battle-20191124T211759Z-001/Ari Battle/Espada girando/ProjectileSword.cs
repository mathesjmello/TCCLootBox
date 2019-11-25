using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSword : MonoBehaviour
{

    public GameObject enemie;
    static float t = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Mathf.Lerp(transform.position.x, enemie.transform.position.x, t), 0, Mathf.Lerp(transform.position.z, enemie.transform.position.z, t));

        t += 10000000000000000000 * Time.deltaTime;
    }
}
