using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthManager : MonoBehaviour {

    public int MaxHealth;
    public int CurrentHealth;
    private PlayerStats thePlayerStats;
    public int expToGive;
    private SFXManager sfxMan;


    // Use this for initialization
    void Start()
    {
        sfxMan = FindObjectOfType<SFXManager>();

        CurrentHealth = MaxHealth;
        thePlayerStats = FindObjectOfType<PlayerStats>();
    }

    // Update is called once per frame
    void Update()
    {
        if (CurrentHealth < 0)
        {
            Destroy(gameObject);
            thePlayerStats.AddExperience(expToGive);
            sfxMan.explosion.Play();
        }
        
    }

    public void HurtEnemy(int damageToGive)
    {
        CurrentHealth -= damageToGive;
        sfxMan.impact.Play();
    }

    public void SetMaxHealth()
    {
        CurrentHealth = MaxHealth;
    }
}
