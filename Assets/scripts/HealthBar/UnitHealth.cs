using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitHealth
{
    private int _currentHealth;
    private int _currentMaxHealth;
    // Start is called before the first frame update
    public int Health
    {
        get
        {
            return _currentHealth;
        }
        set
        {
            _currentHealth = value;
        }
        
    }
    public int MaxHealth
    {
        get
        {
            return _currentMaxHealth;
        }
        set
        {
            _currentMaxHealth = value;
        }
        
    }
    //constructer btw
    public UnitHealth(int health, int maxHealth)
    {
        _currentHealth = health;
        _currentMaxHealth = maxHealth;
    }

    public void DmgUnit(int dmgAmount)
    {
        if (_currentHealth > 0)
        {
            _currentHealth -= dmgAmount;
        }
    }  
    public void HealUnit(int HealAmount)
    {
        if (_currentHealth < _currentMaxHealth)
        {
            _currentHealth += HealAmount;
        }
        if(_currentHealth >_currentMaxHealth)
        {
            _currentHealth = _currentMaxHealth;
        }
    }

}
