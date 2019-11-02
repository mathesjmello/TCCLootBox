using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey;

public class HealthHandler : MonoBehaviour
{
    public HealthBar healthBar;

    // Start is called before the first frame update
    private void Start()
    {
      HealthSystem healthSystem = new HealthSystem(100);
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
