using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem 
{
    public int health;
    // Start is called before the first frame update
    public HealthSystem(int health) 
    {
    	this.health = health
    } 
    
    public int GetHealth() {
    	return health;
    }

    public void Damage(int damageAmount)
    {
    	health += damageAmount;
    }

    public void {
    	
    }
}
