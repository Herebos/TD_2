using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public static int FirePower = 50;
    public float damage;

    private void Start()
    {
        damage = FirePower;
        StartCoroutine(DestroyAfterX());
    }
    private void Update()
    {
        damage = FirePower;
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

}
