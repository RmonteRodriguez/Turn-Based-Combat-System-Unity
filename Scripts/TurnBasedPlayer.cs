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

    public void Attack()
    {
        if (turnBasedCombatManager.playersTurn == false) return;

        int t_critChance = Random.Range(0, 10);

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
    }

    public void Heal()
    {
        if (turnBasedCombatManager.playersTurn == false) return;

        if (health < 100)
        {

            health = health + healAmount;

            turnBasedCombatManager.playersTurn = false;
        }
    }

    public void Switch()
    {
        dialogueBoxText.text = "CANNOT SWITCH AT THIS TIME...";
    }

    public void Bag()
    {
        dialogueBoxText.text = "YOU HAVE NO ITEMS IN YOUR BAG...";
    }

    public void UpdateHealth()
    {
        currentHealthText.text = health + "";

        float t_health_ratio = health / maxHealth;
        healthBar.localScale = new Vector3(t_health_ratio, 1, 1);
    }
}
