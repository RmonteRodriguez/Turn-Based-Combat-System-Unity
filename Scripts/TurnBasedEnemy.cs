//Code written by Remote Dev
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurnBasedEnemy : MonoBehaviour
{
    public TurnBasedCombatManager turnBasedCombatManager;
    public TurnBasedPlayer turnBasedPlayer;

    public int health;
    public int damageAmount;
    public int healAmount;

    //UI
    public Text dialogueBoxText;

    // Start is called before the first frame update
    void Start()
    {
        turnBasedCombatManager = GameObject.Find("Game Manager").GetComponent<TurnBasedCombatManager>();
        turnBasedPlayer = GameObject.Find("Player").GetComponent<TurnBasedPlayer>();

        health = 100;
    }

    // Update is called once per frame
    void Update()
    {
        if (turnBasedCombatManager.timer < 0)
        {
            EnemyTurn();
        }
    }

    //This function is called when the enemy attacks
    public void AttackPlayer()
    {
        int t_critChance = Random.Range(0, 10);

        if (t_critChance > 8)
        {
            turnBasedPlayer.health = turnBasedPlayer.health - (damageAmount * 2);
        }
        else
        {
            turnBasedPlayer.health = turnBasedPlayer.health - damageAmount;
        }

        dialogueBoxText.text = "THE ENEMY ATTACKS BACK WITH ALL THE STRENGTH IS HAS";
    }

    //This function heals the enemy
    public void HealSelf()
    {
        health = health + healAmount;

        dialogueBoxText.text = "THE ENEMY HEALED THEMSELVES BRINGING THEIR HEALTH TO " + health;
    }

    //The enemy turn function will randomly generate a number and if that number is above 8 and the enemy's health is lower than 100 they will heal otherwise they will just attack
    public void EnemyTurn()
    {
        if (turnBasedCombatManager.playersTurn == true) return;

        int t_healChance = Random.Range(0, 10);

        if (t_healChance > 8 && health < 100)
        {
            HealSelf();
        }
        else
        {
            AttackPlayer();
        }

        turnBasedCombatManager.playersTurn = true;
        turnBasedCombatManager.timer = 2;
    }
}
