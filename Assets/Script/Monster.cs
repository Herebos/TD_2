using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Monster : MonoBehaviour
{
    Animator animator;
    public GameObject deathEffect;
    public float health;
    public static float startHealth = 90;
    public static int worth = 50;
    public int monsterWorth;
    [Header("Unity Stuff")]
    public Image healthBar;
    private bool isDead = false;
    
    //Attack
    public static int damageMonster = 10;
    private float nextAttack = 0.0F;
    private float AttackRate = 2.5f;


    private void Start()
    {
        monsterWorth = worth;

        Fresh();
        animator = GetComponent<Animator>();
        GameObject player = GameObject.Find("Player");
        if (player)
        {
            GetComponent<NavMeshAgent>().destination = player.transform.position;
        }
    }
    private void Update()
    {
        monsterWorth = worth;
    }

    private void Fresh()
    {
        health = startHealth;
        isDead = false;
        gameObject.GetComponent<Collider>().enabled = true;
        gameObject.GetComponent<NavMeshAgent>().speed = 3;
    }

    public void TakeDamage(float amount)
    {
        health -= amount;
        healthBar.fillAmount = health / startHealth;
        if (health <= 0 && !isDead)
        {
            PlayerStats.Money += monsterWorth;
            Die();
        }
    }

    void Die()
    {
        isDead = true;
        WaveSpawner.EnemiesAlive--;
        gameObject.transform.position = new Vector3(transform.position.x, 0, transform.position.z);
        //Avec l'effet Death
        //NOTE : avec l'effet Death, plus besoin de stopper le mouvement car mort instantanée
        GameObject effectIns = (GameObject)Instantiate(deathEffect, transform.position, transform.rotation);
        Destroy(effectIns, 1f);
        Destroy(gameObject);
    }


    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "Player")
        {
            PlayerStats.Lives -= 1;
            Die();
        }
        Wall wall = col.gameObject.GetComponent<Wall>();
        if (col.gameObject.CompareTag("Wall"))
        {
            nextAttack = Time.time + AttackRate;
            wall.TakeDamageFromMonster(damageMonster);
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        Wall wall = collision.gameObject.GetComponent<Wall>();
        if (collision.gameObject.CompareTag("Wall") && Time.time > nextAttack)
        {
            nextAttack = Time.time + AttackRate;
            wall.TakeDamageFromMonster(damageMonster);
        }
    }

}
