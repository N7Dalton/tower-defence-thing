using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    private float health;
    public float maxHealth;
    public Image frontHealthBar;
    public Image backHealthBar;
    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;   
    }

    // Update is called once per frame
    void Update()
    {
        health = Mathf.Clamp(health, 0, maxHealth);
        UpdateHealthUI();

    }
    public void UpdateHealthUI()
    {
        

    }

    public void TakeDamage(float damage)
    {
        health -= damage;

    }

}
