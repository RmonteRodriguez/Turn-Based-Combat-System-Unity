using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnBasedPlayer : MonoBehaviour
{
    public TurnBasedCombatManager turnBasedCombatManager;
    public TurnBasedEnemy turnBasedEnemy;

    public int health;
    public int damageAmount;
    public int healAmount;
    
    // Start is called before the first frame update
    void Start()
    {
        turnBasedCombatManager = GameObject.Find("Game Manager").GetComponent<TurnBasedCombatManager>();
        turnBasedEnemy = GameObject.Find("Enemy").GetComponent<TurnBasedEnemy>();

        health = 100;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Attack()
    {
        if (turnBasedCombatManager.playersTurn == false) return;

        int t_critChance = Random.Range(0, 10);

        if (t_critChance > 8)
        {
            turnBasedEnemy.health = turnBasedEnemy.health - (damageAmount * 2);
        }
        else
        {
            turnBasedEnemy.health = turnBasedEnemy.health - damageAmount;
        }

        turnBasedCombatManager.playersTurn = false;
    }

    public void Heal()
    {
        if (turnBasedCombatManager.playersTurn == false) return;

        health = health + healAmount;

        turnBasedCombatManager.playersTurn = false;
    }

    public void Switch()
    {

    }
}
