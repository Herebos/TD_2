using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Gun : MonoBehaviour
{

    public static float TmBtSh = 1.0f;
    public float timeBetweenShots;
    private float nextFire = 0.0F;
    public GameObject bulletPrefab;
    public GameObject player;
    public Transform canon;
    public static int BulletSpeed = 100;
    public int bulletSpeed;

    void Start()
    {
        bulletSpeed = BulletSpeed;
        timeBetweenShots = TmBtSh;
    }
    private void Update()
    {
        GetComponent<LineRenderer>().SetPosition(0, new Vector3(transform.position.x, transform.position.y, transform.position.z));
        //LaserSight
        RaycastHit hit;
        if(Physics.Raycast(transform.position, transform.forward, out hit))
        {
            GetComponent<LineRenderer>().SetPosition(1, new Vector3(hit.point.x, transform.position.y, hit.point.z));
        }

        timeBetweenShots = TmBtSh;
        bulletSpeed = BulletSpeed;
    }

    private void FixedUpdate()
    {
        if (Input.GetMouseButton(0) && Time.time > nextFire)
        {
            nextFire = Time.time + timeBetweenShots;
            Fire();
        }
    }

    
    public void Fire()
    {
        GameObject bullet = (GameObject)Instantiate(bulletPrefab, transform.position, Quaternion.Euler(0,0,90));
        Physics.IgnoreCollision(bullet.GetComponent<Collider>(), player.GetComponent<Collider>());
        bullet.GetComponent<Rigidbody>().AddForce(canon.forward * bulletSpeed, ForceMode.Impulse);
    }
}
