using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey;

public class HealthHandler : MonoBehaviour
{
    // public HealthBar healthBar;
	public Transform HealthBarPrefab;

    // Start is called before the first frame update
    private void Start()
    {
      HealthSystem healthSystem = new HealthSystem(100);
   		
   		Transform healthBarTransform = Instantiate(HealthBarPrefab, new Vector3(transform.position.x, (transform.position.y + 1f)), Quaternion.identity);
   		
   		HealthBar healthBar = healthBarTransform.GetComponent<HealthBar>();
   		healthBar.Setup(healthSystem);	

    	CMDebug.ButtonUI(new Vector2(100,100), "damage", () => {
    		healthSystem.Damage(10);
    		Debug.Log("Damaged: "+healthSystem.GetHealth());
  		});

  		CMDebug.ButtonUI(new Vector2(-100,100), "heal", () => {
    		healthSystem.Heal(10);
    		Debug.Log("Healed: "+healthSystem.GetHealth());
  		});
  	
  	}

}
