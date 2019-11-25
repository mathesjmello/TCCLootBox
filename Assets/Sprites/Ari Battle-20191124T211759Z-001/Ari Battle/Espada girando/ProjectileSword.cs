using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSword : MonoBehaviour
{

    public GameObject enemie;
    public Transform Player;
    public Transform Enemie;

    [Range(0f, 1f)]
    public float lerpPct = 0.0f;

    //static float t = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(Player.position, Enemie.position, lerpPct);

        if (lerpPct < 1.0f)
        {
            lerpPct += 0.1f;
        }
        else if (lerpPct >= 1.0f)
        {
            Destroy(gameObject);
            //gameObject.SetActive(false);
            //lerpPct = 0.0f;
        }
        //transform.Translate(Mathf.Lerp(transform.position.x, enemie.transform.position.x, t), 0, Mathf.Lerp(transform.position.z, enemie.transform.position.z, t));

        //t += 10000000000000000000 * Time.deltaTime;
    }
}
