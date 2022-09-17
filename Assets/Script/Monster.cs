using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Monster : MonoBehaviour
{
    Animator animator;
    public GameObject deathEffect;
    public float startHealth = 100;
    private float health;
    public int worth = 50;
    [Header("Unity Stuff")]
    //public Image healthBar;
    private bool isDead = false;

    private void Start()
    {
        Fresh();
        animator = GetComponent<Animator>();
        GameObject player = GameObject.Find("Player");
        if (player)
        {
            GetComponent<NavMeshAgent>().destination = player.transform.position;
        }
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
        Debug.Log("Vie slime: " + health);
        //healthBar.fillAmount = health / startHealth;
        if (health <= 0 && !isDead)
        {
            PlayerStats.Money += worth;
            Die();
        }
    }

    void Die()
    {
        isDead = true;
        //gameObject.GetComponent<Collider>().enabled = false;
        //gameObject.GetComponent<NavMeshAgent>().speed = 0;
        gameObject.transform.position = new Vector3(transform.position.x, 0, transform.position.z);
        //Avec l'animation "Die"
        //animator.SetTrigger("die");
        //Destroy(gameObject, 1.1f);

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
            Debug.Log("Player touched");
            PlayerStats.Lives -= 1;
            Die();
        }
    }

}
