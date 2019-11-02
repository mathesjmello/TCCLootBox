using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem 
{
    public int health;
    public int healthMax;
    // Start is called before the first frame update
    public HealthSystem(int healthMax) 
    {
    	this.healthMax = healthMax;
    } 
    
    public int GetHealth() {
    	return health;
    }

    public float GetHealthPercent() {
    	return health / healthMax;
    }

    public void Damage(int damageAmount)
    {
    	health -= damageAmount;
    	if (health < 0) health = 0;
    }

    public void Heal(int healAmount) {
    	health += healAmount;
    	if (health > healthMax) health = healthMax;
    }

}
