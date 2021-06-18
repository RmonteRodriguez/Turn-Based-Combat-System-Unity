using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnBasedCombatManager : MonoBehaviour
{
    public GameObject player;
    public GameObject enemy;

    public int turnNumber;

    public bool enemysTurn;
    public bool playersTurn;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        enemy = GameObject.FindGameObjectWithTag("Enemy");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
