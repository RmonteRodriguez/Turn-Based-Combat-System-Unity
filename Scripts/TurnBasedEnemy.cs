using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnBasedEnemy : MonoBehaviour
{
    public TurnBasedCombatManager turnBasedCombatManager;
    public TurnBasedPlayer turnBasedPlayer;

    public int health;
    public int damageAmount;
    public int healAmount;

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
        AttackPlayer();
    }

    public void AttackPlayer()
    {
        if (turnBasedCombatManager.playersTurn == true) return;

        int t_critChance = Random.Range(0, 10);

        if (t_critChance > 8)
        {
            turnBasedPlayer.health = turnBasedPlayer.health - (damageAmount * 2);
        }
        else
        {
            turnBasedPlayer.health = turnBasedPlayer.health - damageAmount;
        }

        turnBasedCombatManager.playersTurn = true;
    }

    public void HealSelf()
    {

    }
}
