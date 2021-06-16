using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnBasedEnemy : MonoBehaviour
{
    public TurnBasedCombatManager turnBasedCombatManager; 

    public int health;

    // Start is called before the first frame update
    void Start()
    {
        turnBasedCombatManager = GameObject.Find("Game Manager").GetComponent<TurnBasedCombatManager>();

        health = 100;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AttackPlayer()
    {

    }

    public void HealSelf()
    {

    }
}
