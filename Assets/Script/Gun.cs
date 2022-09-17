using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public float timeBetweenShots;
    private float nextFire = 0.0F;

    private void FixedUpdate()
    {
        if (Input.GetMouseButton(0) && Time.time > nextFire)
        {
            nextFire = Time.time + timeBetweenShots;
            Fire();
        }
    }


    public GameObject bulletPrefab;
    public GameObject player;
    public Transform canon;
    public float bulletSpeed;
    public void Fire()
    {
        GameObject bullet = (GameObject)Instantiate(bulletPrefab, transform.position, Quaternion.Euler(0,0,90));
        Physics.IgnoreCollision(bullet.GetComponent<Collider>(), player.GetComponent<Collider>());
        bullet.GetComponent<Rigidbody>().AddForce(canon.forward * bulletSpeed, ForceMode.Impulse);
    }
}
