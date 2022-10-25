using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Gun : MonoBehaviour
{
    private static LineRenderer lr;
    public static float TmBtSh = 1.0f;
    public float timeBetweenShots;
    private float nextFire = 0.0F;
    public GameObject bulletPrefab;
    public GameObject muzzleFlash;
    public GameObject Player;
    public GameObject Wall;
    public Transform canon;
    public static int BulletSpeed = 100;
    public int bulletSpeed;

    void Start()
    {
        bulletSpeed = BulletSpeed;
        timeBetweenShots = TmBtSh;
        lr = gameObject.GetComponent<LineRenderer>();
    }
    private void Update()
    {
        lr.SetPosition(0, new Vector3(transform.position.x, transform.position.y, transform.position.z));
        //LaserSight
        RaycastHit hit;
        if(Physics.Raycast(transform.position, transform.forward, out hit))
        {
            lr.SetPosition(1, new Vector3(hit.point.x, transform.position.y, hit.point.z));
        }

        timeBetweenShots = TmBtSh;
        bulletSpeed = BulletSpeed;
    }

    private void FixedUpdate()
    {
        if (Input.GetMouseButton(0) && Time.time > nextFire)
        {
            nextFire = Time.time + timeBetweenShots;
            MuzzleFunc();
            Fire();
        }
    }

    public static void ActivateLaserSight()
    {
        lr.enabled = true;
    }
    
    public void Fire()
    {
        GameObject bullet = (GameObject)Instantiate(bulletPrefab, transform.position, Quaternion.Euler(0,0,90));
        Physics.IgnoreCollision(bullet.GetComponent<Collider>(), Player.GetComponent<Collider>());
        Physics.IgnoreCollision(bullet.GetComponent<Collider>(), Wall.GetComponent<Collider>());
        bullet.GetComponent<Rigidbody>().AddForce(canon.forward * bulletSpeed, ForceMode.Impulse);
    }
    public void MuzzleFunc()
    {
        muzzleFlash.SetActive(true);
        Invoke(nameof(SetFalse), 0.1f);
    }
    void SetFalse()
    {
        muzzleFlash.SetActive(false);
    }
}
