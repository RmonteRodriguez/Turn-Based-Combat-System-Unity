//Code written by Remote Dev
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurnBasedPlayer : MonoBehaviour
{
    public TurnBasedCombatManager turnBasedCombatManager;
    public TurnBasedEnemy turnBasedEnemy;

    private float maxHealth = 100;
    public float health;

    public int damageAmount;
    public int healAmount;

    //UI
    public Text currentHealthText;
    public Text dialogueBoxText;

    private Transform healthBar;
    
    // Start is called before the first frame update
    void Start()
    {
        turnBasedCombatManager = GameObject.Find("Game Manager").GetComponent<TurnBasedCombatManager>();
        turnBasedEnemy = GameObject.Find("Enemy").GetComponent<TurnBasedEnemy>();

        healthBar = GameObject.Find("Main Bar").transform;

        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateHealth();
    }

    //This function is used when the player attacks
    public void Attack()
    {
        if (turnBasedCombatManager.playersTurn == false) return;

        if (turnBasedCombatManager.timer < 0)
        {
            int t_critChance = Random.Range(0, 10);

            //This if statement checks to see if the player has a good enough number for a crit
            if (t_critChance > 8) 
            {
                turnBasedEnemy.health = turnBasedEnemy.health - (damageAmount * 2);

                dialogueBoxText.text = "YOU STRIKE YOUR ENEMY LEAVING THEM WITH " + turnBasedEnemy.health + " HP.";
            }
            else
            {
                turnBasedEnemy.health = turnBasedEnemy.health - damageAmount;

                dialogueBoxText.text = "YOU STRIKE YOUR ENEMY LEAVING THEM WITH " + turnBasedEnemy.health + " HP.";
            }

            turnBasedCombatManager.playersTurn = false;
            turnBasedCombatManager.timer = 2;
        }
        else
        {
            dialogueBoxText.text = "YOU CANNOT ATTACK AT THIS TIME";
        }
    }

    //This function is used when the player heals
    public void Heal()
    {
        if (turnBasedCombatManager.playersTurn == false) return;

        if (turnBasedCombatManager.timer >= 0 && health < 100)
        {
            health = health + healAmount;

            turnBasedCombatManager.playersTurn = false;
            turnBasedCombatManager.timer = 2;
        }
        else
        {
            dialogueBoxText.text = "YOU CANNOT HEAL AT THIS TIME";
        }
    }

    //This function is used when the player switches
    public void Switch()
    {
        dialogueBoxText.text = "CANNOT SWITCH AT THIS TIME...";
    }

    //This function is used when the player opens bag
    public void Bag()
    {
        dialogueBoxText.text = "YOU HAVE NO ITEMS IN YOUR BAG...";
    }

    //This function is responsable for making sure the health UI is up to date on the screen
    public void UpdateHealth()
    {
        currentHealthText.text = health + "";

        float t_health_ratio = health / maxHealth;
        healthBar.localScale = new Vector3(t_health_ratio, 1, 1);
    }
}
