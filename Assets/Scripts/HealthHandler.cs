using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthHandler : MonoBehaviour
{
    // Start is called before the first frame update
    private void Start()
    {
      HealthSystem healthSystem = new HealthSystem(100);
   
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
