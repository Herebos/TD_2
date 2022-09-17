using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float damage = 50;

    private void Start()
    {
        StartCoroutine(DestroyAfterX());
    }

    private void OnCollisionEnter(Collision col)
    {
        Monster monster = col.gameObject.GetComponent<Monster>();
        if (col.gameObject.CompareTag("Enemy"))
        {
            monster.TakeDamage(damage);
            Destroy(gameObject);
        }
    }
    
    IEnumerator DestroyAfterX()
    {
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
    }

    /*private void OnTriggerEnter(Collider col)
    {
        Health health = col.GetComponentInChildren<Health>();
        if (health)
        {
            health.Decrease();
            Destroy(gameObject);
        }
    }*/

}
