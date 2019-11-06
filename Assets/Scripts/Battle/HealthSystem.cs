using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class HealthSystem : MonoBehaviour
{
    public event EventHandler OnHealthChange;
    
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
    	return (float)health / healthMax;
    }

    public void Damage(int damageAmount)
    {
    	health -= damageAmount;
    	if (health < 0) health = 0;
    	if (OnHealthChange != null) OnHealthChange(this, EventArgs.Empty);
    }

    public void Heal(int healAmount) {
    	health += healAmount;
    	if (health > healthMax) health = healthMax;
    	if (OnHealthChange != null) OnHealthChange(this, EventArgs.Empty);
    }

}
