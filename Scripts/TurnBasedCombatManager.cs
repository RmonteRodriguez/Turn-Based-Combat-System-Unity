//Code written by Remote Dev
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TurnBasedCombatManager : MonoBehaviour
{
    public TurnBasedPlayer turnBasedPlayer;
    public TurnBasedEnemy turnBasedEnemy;

    public float timer;

    public bool playersTurn;

    // Start is called before the first frame update
    void Start()
    {
        turnBasedEnemy = GameObject.Find("Enemy").GetComponent<TurnBasedEnemy>();
        turnBasedPlayer = GameObject.Find("Player").GetComponent<TurnBasedPlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (turnBasedEnemy.health <= 0 || turnBasedPlayer.health <= 0)
        {
            SceneManager.LoadScene(0);
        }

        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
    }
}
